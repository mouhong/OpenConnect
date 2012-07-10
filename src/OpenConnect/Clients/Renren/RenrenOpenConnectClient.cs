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

        public string GetAuthorizationUrl(AuthorizationUrlParameters parameters)
        {
            return new LoginUrlBuilder("https://graph.renren.com/oauth/authorize")
            {
                OtherParameters = parameters.OtherParameters
            }
            .Build(AppInfo, parameters.ResponseType, parameters.RedirectUri, parameters.Scope, parameters.Display);
        }

        public AccessTokenResponse GetAccessToken(AccessTokenRequestParameters parameters)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://graph.renren.com/oauth/token", _httpClient);
            var response = request.GetResponse(AppInfo, parameters);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            return new RenrenGetUserInfoRequest(_httpClient)
            .GetResponse(AppInfo, parameters.AccessToken);
        }
    }
}
