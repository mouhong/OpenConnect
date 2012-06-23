using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Sina
{
    public class SinaWeiboOpenConnectClient : IOpenConnectClient
    {
        public AppInfo AppInfo { get; private set; }

        public IHttpClient HttpClient { get; private set; }

        public SinaWeiboOpenConnectClient(AppInfo appInfo)
            : this(appInfo, OpenConnect.Clients.HttpClient.Instance)
        {
        }

        public SinaWeiboOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            HttpClient = httpClient;
        }

        public string BuildLoginUrl(string display, ResponseType responseType)
        {
            return new LoginUrlBuilder("https://api.weibo.com/oauth2/authorize")
            .Build(AppInfo, display, responseType);
        }

        public AccessTokenResponse GetAccessToken(string authCode, string state)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://api.weibo.com/oauth2/access_token", HttpClient)
            {
                Method = HttpMethod.Post
            };
            var response = request.GetResponse(AppInfo, authCode, state);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId)
        {
            return new SinaWeiboGetUserInfoRequest(HttpClient)
            .GetResponse(AppInfo, accessToken);
        }
    }
}
