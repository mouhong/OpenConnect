using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;

using OpenConnect.Utils;

namespace OpenConnect.Clients.Utils
{
    public class GetAccessTokenRequest
    {
        public HttpMethod Method { get; set; }

        public string ApiPath { get; private set; }

        public IHttpClient HttpClient { get; private set; }

        public GetAccessTokenRequest(string apiPath, IHttpClient httpClient)
        {
            Require.NotNullOrEmpty(apiPath, "apiPath");
            Require.NotNull(httpClient, "httpClient");

            ApiPath = apiPath;
            HttpClient = httpClient;
        }

        public string GetResponse(AppInfo appInfo, string authCode, string redirectUri, string state)
        {
            Require.NotNull(appInfo, "appInfo");
            Require.NotNullOrEmpty(authCode, "authCode");

            var data = BuildRequestParameters(appInfo, authCode, redirectUri, state);

            if (Method == HttpMethod.Get)
            {
                return HttpClient.Get(ApiPath, data, Encoding.UTF8);
            }

            return HttpClient.Post(ApiPath, data, Encoding.UTF8);
        }

        private NameValueCollection BuildRequestParameters(AppInfo appInfo, string authCode, string redirectUri, string state)
        {
            var data = new NameValueCollection().FluentAdd("client_id", appInfo.AppId)
                                                .FluentAdd("client_secret", appInfo.AppSecret)
                                                .FluentAdd("redirect_uri", redirectUri)
                                                .FluentAdd("code", authCode)
                                                .FluentAdd("grant_type", "authorization_code")
                                                .AddIfValueIsNotNullOrEmpty("state", state);

            return data;
        }
    }
}
