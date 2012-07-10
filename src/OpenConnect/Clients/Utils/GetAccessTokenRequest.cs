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

        public string GetResponse(AppInfo appInfo, AccessTokenRequestParameters parameters)
        {
            Require.NotNull(appInfo, "appInfo");
            Require.NotNull(parameters, "parameters");

            var data = BuildRequestParameters(appInfo, parameters);

            if (Method == HttpMethod.Get)
            {
                return HttpClient.Get(ApiPath, data, Encoding.UTF8);
            }

            return HttpClient.Post(ApiPath, data, Encoding.UTF8);
        }

        private NameValueCollection BuildRequestParameters(AppInfo appInfo, AccessTokenRequestParameters parameters)
        {
            var data = new NameValueCollection().FluentAdd("client_id", appInfo.AppId)
                                                .FluentAdd("client_secret", appInfo.AppSecret)
                                                .FluentAdd("redirect_uri", parameters.RedirectUri)
                                                .FluentAdd("code", parameters.AuthorizationCode)
                                                .FluentAdd("grant_type", "authorization_code")
                                                .AddIfValueIsNotNullOrEmpty("state", parameters.State);

            if (parameters.OtherParameters != null && parameters.OtherParameters.Count > 0)
            {
                foreach (var key in parameters.OtherParameters.AllKeys)
                {
                    data.Add(key, parameters.OtherParameters[key]);
                }
            }

            return data;
        }
    }
}
