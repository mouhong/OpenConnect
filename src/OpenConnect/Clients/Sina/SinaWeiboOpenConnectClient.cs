using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients.Utils;
using OpenConnect.Utils;

namespace OpenConnect.Clients.Sina
{
    public class SinaWeiboOpenConnectClient : IOpenConnectClient
    {
        private IHttpClient _httpClient;

        public AppInfo AppInfo { get; private set; }

        public SinaWeiboOpenConnectClient(AppInfo appInfo)
            : this(appInfo, HttpClient.Instance)
        {
        }

        public SinaWeiboOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            _httpClient = httpClient;
        }

        public string GetAuthorizationUrl(AuthorizationUrlParameters parameters)
        {
            return new LoginUrlBuilder("https://api.weibo.com/oauth2/authorize")
            {
                OtherParameters = parameters.OtherParameters
            }
            .Build(AppInfo, parameters.ResponseType, parameters.RedirectUri, parameters.Scope, parameters.Display);
        }

        public AccessTokenResponse GetAccessToken(AccessTokenRequestParameters parameters)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://api.weibo.com/oauth2/access_token", _httpClient)
            {
                Method = HttpMethod.Post
            };
            var response = request.GetResponse(AppInfo, parameters);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            return new SinaWeiboGetUserInfoRequest(_httpClient).GetResponse(AppInfo, parameters.AccessToken);
        }
    }
}
