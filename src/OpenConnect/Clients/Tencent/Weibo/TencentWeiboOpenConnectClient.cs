using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Tencent.Weibo
{
    public class TencentWeiboOpenConnectClient : IOpenConnectClient
    {
        public AppInfo AppInfo { get; private set; }

        public IHttpClient HttpClient { get; private set; }

        public TencentWeiboOpenConnectClient(AppInfo appInfo)
            : this(appInfo, OpenConnect.Clients.HttpClient.Instance)
        {
        }

        public TencentWeiboOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            HttpClient = httpClient;
        }

        public string BuildLoginUrl(string display, ResponseType responseType)
        {
            return new LoginUrlBuilder("https://open.t.qq.com/cgi-bin/oauth2/authorize")
            .Build(AppInfo, display, responseType);
        }

        public AccessTokenResponse GetAccessToken(string authCode, string state)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://open.t.qq.com/cgi-bin/oauth2/access_token", HttpClient);
            var response = request.GetResponse(AppInfo, authCode, state);

            return TencentGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId)
        {
            return new TencentWeiboGetUserInfoRequest(HttpClient)
                .GetResponse(AppInfo, accessToken, userId);
        }
    }
}
