using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Google
{
    public class GoogleOpenConnectClient : IOpenConnectClient
    {
        public AppInfo AppInfo { get; private set; }

        public IHttpClient HttpClient { get; private set; }

        public GoogleOpenConnectClient(AppInfo appInfo)
            : this(appInfo, OpenConnect.Clients.HttpClient.Instance)
        {
        }

        public GoogleOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            HttpClient = httpClient;
        }

        public string BuildLoginUrl(string display, ResponseType responseType)
        {
            var builder = new LoginUrlBuilder("https://accounts.google.com/o/oauth2/auth");
            builder.DisplayParamName = "approval_prompt";

            return builder.Build(AppInfo, display, responseType);
        }

        public AccessTokenResponse GetAccessToken(string authCode, string state)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://accounts.google.com/o/oauth2/token", HttpClient);
            var response = request.GetResponse(AppInfo, authCode, null);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId)
        {
            return new GoogleGetUserInfoRequest(HttpClient).GetResponse(AppInfo, accessToken);
        }
    }
}
