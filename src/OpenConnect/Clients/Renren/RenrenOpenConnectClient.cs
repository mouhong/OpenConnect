using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients.Utils;
using OpenConnect.Utils;

namespace OpenConnect.Clients.Renren
{
    public class RenrenOpenConnectClient : IOpenConnectClient
    {
        private IHttpClient _httpClient;

        public AppInfo AppInfo { get; private set; }

        public RenrenOpenConnectClient(AppInfo appInfo)
            : this(appInfo, HttpClient.Instance)
        {
        }

        public RenrenOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            _httpClient = httpClient;
        }

        public string BuildLoginUrl(ResponseType responseType, string redirectUri, string scope, string display)
        {
            return new LoginUrlBuilder("https://graph.renren.com/oauth/authorize")
                .Build(AppInfo, responseType, redirectUri, scope, display);
        }

        public AccessTokenResponse GetAccessToken(string authCode, string redirectUri, string state)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://graph.renren.com/oauth/token", _httpClient);
            var response = request.GetResponse(AppInfo, authCode, redirectUri, state);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId)
        {
            return new RenrenGetUserInfoRequest(_httpClient)
            .GetResponse(AppInfo, accessToken);
        }
    }
}
