using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Utils;

namespace OpenConnect.Providers.Live
{
    public class LiveUserInfoRequest : IUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public LiveUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            var url = UrlBuilder.Create("https://apis.live.net/v5.0/me")
                                .WithParam("access_token", parameters.AccessTokenResponse.AccessToken)
                                .Build();

            var json = HttpClient.Get(url, null, Encoding.UTF8);

            return ParseRawResponse(json);
        }

        protected virtual IUserInfo ParseRawResponse(string jsonResponse)
        {
            return (LiveUserInfo)JsonSerializer.Deserialize(jsonResponse, typeof(LiveUserInfo));
        }
    }
}
