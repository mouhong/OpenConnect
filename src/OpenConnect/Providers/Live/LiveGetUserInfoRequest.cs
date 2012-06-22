using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Utils;

namespace OpenConnect.Providers.Live
{
    public class LiveGetUserInfoRequest : IGetUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public LiveGetUserInfoRequest()
            : this(OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public LiveGetUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public IUserInfo GetResponse(AppInfo appInfo, string accessToken, string userId)
        {
            var url = UrlBuilder.Create("https://apis.live.net/v5.0/me")
                                .WithParam("access_token", accessToken)
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
