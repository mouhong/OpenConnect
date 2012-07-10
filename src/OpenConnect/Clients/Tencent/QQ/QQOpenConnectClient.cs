using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Tencent.QQ
{
    public class QQOpenConnectClient : IOpenConnectClient
    {
        private IHttpClient _httpClient;

        public AppInfo AppInfo { get; private set; }

        public QQOpenConnectClient(AppInfo appInfo)
            : this(appInfo, HttpClient.Instance)
        {
        }

        public QQOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            _httpClient = httpClient;
        }

        public string GetAuthorizationUrl(AuthorizationUrlParameters parameters)
        {
            return new LoginUrlBuilder("https://graph.qq.com/oauth2.0/authorize")
            {
                OtherParameters = parameters.OtherParameters
            }
            .Build(AppInfo, parameters.ResponseType, parameters.RedirectUri, parameters.Scope, parameters.Display);
        }

        public AccessTokenResponse GetAccessToken(AccessTokenRequestParameters parameters)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://graph.qq.com/oauth2.0/token", _httpClient);
            var response = request.GetResponse(AppInfo, parameters);

            return TencentGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            return new QQGetUserInfoRequest(_httpClient)
            .GetResponse(AppInfo, parameters.AccessToken);
        }
    }
}
