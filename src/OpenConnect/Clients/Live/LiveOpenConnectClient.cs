using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Live
{
    public class LiveOpenConnectClient : IOpenConnectClient
    {
        public AppInfo AppInfo { get; private set; }

        public IHttpClient HttpClient { get; private set; }

        public LiveOpenConnectClient(AppInfo appInfo)
            : this(appInfo, OpenConnect.Clients.HttpClient.Instance)
        {
        }

        public LiveOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            HttpClient = httpClient;
        }

        public string BuildLoginUrl(string display, ResponseType responseType)
        {
            return new LoginUrlBuilder("https://oauth.live.com/authorize")
                .Build(AppInfo, display, responseType);
        }

        public AccessTokenResponse GetAccessToken(string authCode, string state)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://oauth.live.com/token", HttpClient)
            {
                Method = HttpMethod.Get
            };
            var response = request.GetResponse(AppInfo, authCode, state);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId)
        {
            return new LiveGetUserInfoRequest(HttpClient).GetResponse(AppInfo, accessToken);
        }
    }
}
