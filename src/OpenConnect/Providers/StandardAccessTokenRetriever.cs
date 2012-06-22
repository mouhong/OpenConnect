using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;

using OpenConnect.Utils;

namespace OpenConnect.Providers
{
    public class StandardAccessTokenRetriever : IAccessTokenRetriever
    {
        public HttpMethod Method { get; set; }

        public string ApiPath { get; private set; }

        public IHttpClient HttpClient { get; private set; }

        public StandardAccessTokenRetriever(string apiPath)
            : this(apiPath, OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public StandardAccessTokenRetriever(string apiPath, IHttpClient httpClient)
        {
            Check.RequireNotNullOrEmpty(apiPath, "apiPath");
            Check.RequireNotNull(httpClient, "httpClient");

            ApiPath = apiPath;
            HttpClient = httpClient;
        }

        public AccessToken Retrieve(AppInfo appInfo, string authCode, string state)
        {
            Check.RequireNotNull(appInfo, "appInfo");
            Check.RequireNotNullOrEmpty(authCode, "authCode");

            var now = DateTime.Now;
            var response = GetResponse(appInfo, authCode, state);
            return ParseResponse(response, now);
        }

        protected virtual string GetResponse(AppInfo appInfo, string authCode, string state)
        {
            var data = new NameValueCollection().FluentAdd("client_id", appInfo.AppId)
                                                .FluentAdd("client_secret", appInfo.AppSecret)
                                                .FluentAdd("redirect_uri", appInfo.RedirectUri)
                                                .FluentAdd("code", authCode)
                                                .FluentAdd("grant_type", "authorization_code")
                                                .AddIfValueIsNotNullOrEmpty("state", state);

            if (Method == HttpMethod.Get)
            {
                return HttpClient.Get(ApiPath, data, Encoding.UTF8);
            }

            return HttpClient.Post(ApiPath, data, Encoding.UTF8);
        }

        protected virtual AccessToken ParseResponse(string response, DateTime startRequestTime)
        {
            var result = (GetAccessTokenResult)JsonSerializer.Deserialize(response, typeof(GetAccessTokenResult));

            return new AccessToken(result.access_token, startRequestTime.AddSeconds( result.expires_in), result.refresh_token);
        }

        public virtual AccessToken Refresh(AppInfo appInfo, string refreshToken)
        {
            throw new NotSupportedException();
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
