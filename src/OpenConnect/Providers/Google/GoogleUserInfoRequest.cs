using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Utils;

namespace OpenConnect.Providers.Google
{
    public class GoogleUserInfoRequest : IUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public GoogleUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            var url = UrlBuilder.Create("https://www.googleapis.com/oauth2/v1/userinfo")
                                .WithParam("alt", "json")
                                .WithParam("access_token", parameters.AccessTokenResult.AccessToken)
                                .Build();

            var json = HttpClient.Get(url, null, Encoding.UTF8);

            return ParseRawResponse(json);
        }

        private IUserInfo ParseRawResponse(string jsonResponse)
        {
            return (GoogleUserInfo)JsonSerializer.Deserialize(jsonResponse, typeof(GoogleUserInfo));
        }
    }
}
