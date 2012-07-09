using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Google
{
    public class GoogleOpenConnectClient : IOpenConnectClient
    {
        private IHttpClient _httpClient;

        public AppInfo AppInfo { get; private set; }

        public GoogleOpenConnectClient(AppInfo appInfo)
            : this(appInfo, HttpClient.Instance)
        {
        }

        public GoogleOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            _httpClient = httpClient;
        }

        public string BuildLoginUrl(ResponseType responseType, string redirectUri, string scope, string display)
        {
            var builder = new LoginUrlBuilder("https://accounts.google.com/o/oauth2/auth");
            builder.DisplayParamName = "approval_prompt";

            return builder.Build(AppInfo, responseType, redirectUri, scope, display);
        }

        public AccessTokenResponse GetAccessToken(string authCode, string redirectUri, string state)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://accounts.google.com/o/oauth2/token", _httpClient);
            var response = request.GetResponse(AppInfo, authCode, redirectUri, null);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId)
        {
            return new GoogleGetUserInfoRequest(_httpClient).GetResponse(AppInfo, accessToken);
        }
    }
}
