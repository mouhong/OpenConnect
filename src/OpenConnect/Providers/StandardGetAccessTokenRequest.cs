using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;

using OpenConnect.Utils;

namespace OpenConnect.Providers
{
    public class StandardGetAccessTokenRequest : IGetAccessTokenRequest
    {
        public HttpMethod Method { get; set; }

        public string ApiPath { get; private set; }

        public IHttpClient HttpClient { get; private set; }

        public StandardGetAccessTokenRequest(string apiPath)
            : this(apiPath, OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public StandardGetAccessTokenRequest(string apiPath, IHttpClient httpClient)
        {
            Require.NotNullOrEmpty(apiPath, "apiPath");
            Require.NotNull(httpClient, "httpClient");

            ApiPath = apiPath;
            HttpClient = httpClient;
        }

        public AccessToken GetResponse(AppInfo appInfo, string authCode, string state)
        {
            Require.NotNull(appInfo, "appInfo");
            Require.NotNullOrEmpty(authCode, "authCode");

            var now = DateTime.Now;
            var response = GetRawResponse(appInfo, authCode, state);
            return ParseRawResponse(response, now);
        }

        protected virtual NameValueCollection BuildRequestParameters(AppInfo appInfo, string authCode, string state)
        {
            var data = new NameValueCollection().FluentAdd("client_id", appInfo.AppId)
                                                .FluentAdd("client_secret", appInfo.AppSecret)
                                                .FluentAdd("redirect_uri", appInfo.RedirectUri)
                                                .FluentAdd("code", authCode)
                                                .FluentAdd("grant_type", "authorization_code")
                                                .AddIfValueIsNotNullOrEmpty("state", state);

            return data;
        }

        protected virtual string GetRawResponse(AppInfo appInfo, string authCode, string state)
        {
            var data = BuildRequestParameters(appInfo, authCode, state);

            if (Method == HttpMethod.Get)
            {
                return HttpClient.Get(ApiPath, data, Encoding.UTF8);
            }

            return HttpClient.Post(ApiPath, data, Encoding.UTF8);
        }

        protected virtual AccessToken ParseRawResponse(string response, DateTime startRequestTime)
        {
            var result = (GetAccessTokenResult)JsonSerializer.Deserialize(response, typeof(GetAccessTokenResult));

            return new AccessToken(result.access_token, startRequestTime.AddSeconds( result.expires_in), result.refresh_token);
        }

        [DataContract]
        private class GetAccessTokenResult
        {
            [DataMember]
            public string access_token = null;

            [DataMember]
            public int expires_in = 0;

            [DataMember]
            public string refresh_token = null;
        }
    }
}
