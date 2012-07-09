using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients.Utils;
using OpenConnect.Utils;

namespace OpenConnect.Clients.Live
{
    public class LiveOpenConnectClient : IOpenConnectClient
    {
        private IHttpClient _httpClient;

        public AppInfo AppInfo { get; private set; }

        public LiveOpenConnectClient(AppInfo appInfo)
            : this(appInfo, HttpClient.Instance)
        {
        }

        public LiveOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            _httpClient = httpClient;
        }

        public string BuildLoginUrl(ResponseType responseType, string redirectUri, string scope, string display)
        {
            return new LoginUrlBuilder("https://oauth.live.com/authorize")
                .Build(AppInfo, responseType, redirectUri, scope, display);
        }

        public AccessTokenResponse GetAccessToken(string authCode, string redirectUri, string state)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://oauth.live.com/token", _httpClient)
            {
                Method = HttpMethod.Get
            };
            var response = request.GetResponse(AppInfo, authCode, redirectUri, state);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId)
        {
            return new LiveGetUserInfoRequest(_httpClient).GetResponse(AppInfo, accessToken);
        }
    }
}
