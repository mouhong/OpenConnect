using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Renren
{
    public class RenrenOpenConnectClient : IOpenConnectClient
    {
        public AppInfo AppInfo { get; private set; }

        public IHttpClient HttpClient { get; private set; }

        public RenrenOpenConnectClient(AppInfo appInfo)
            : this(appInfo, OpenConnect.Clients.HttpClient.Instance)
        {
        }

        public RenrenOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            HttpClient = httpClient;
        }

        public string BuildLoginUrl(string display, ResponseType responseType)
        {
            return new LoginUrlBuilder("https://graph.renren.com/oauth/authorize")
                .Build(AppInfo, display, responseType);
        }

        public AccessTokenResponse GetAccessToken(string authCode, string state)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://graph.renren.com/oauth/token", HttpClient);
            var response = request.GetResponse(AppInfo, authCode, state);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId)
        {
            return new RenrenGetUserInfoRequest(HttpClient)
            .GetResponse(AppInfo, accessToken);
        }
    }
}
