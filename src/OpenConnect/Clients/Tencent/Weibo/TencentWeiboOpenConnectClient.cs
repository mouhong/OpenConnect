using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Tencent.Weibo
{
    public class TencentWeiboOpenConnectClient : IOpenConnectClient
    {
        private IHttpClient _httpClient;

        public AppInfo AppInfo { get; private set; }

        public TencentWeiboOpenConnectClient(AppInfo appInfo)
            : this(appInfo, HttpClient.Instance)
        {
        }

        public TencentWeiboOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            _httpClient = httpClient;
        }

        public string GetAuthorizationUrl(AuthorizationUrlParameters parameters)
        {
            return new LoginUrlBuilder("https://open.t.qq.com/cgi-bin/oauth2/authorize")
            {
                OtherParameters = parameters.OtherParameters
            }
            .Build(AppInfo, parameters.ResponseType, parameters.RedirectUri, parameters.Scope, parameters.Display);
        }

        public AccessTokenResponse GetAccessToken(AccessTokenRequestParameters parameters)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://open.t.qq.com/cgi-bin/oauth2/access_token", _httpClient);
            var response = request.GetResponse(AppInfo, parameters);

            return TencentGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            var openid = parameters.OtherParameters["openid"];

            if (String.IsNullOrEmpty(openid))
                throw new ApiException("Requires 'openid' parameter.");

            return new TencentWeiboGetUserInfoRequest(_httpClient).GetResponse(AppInfo, parameters.AccessToken, openid);
        }
    }
}
