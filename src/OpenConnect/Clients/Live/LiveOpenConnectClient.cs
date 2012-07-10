using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients.Utils;
using OpenConnect.Utils;

namespace OpenConnect.Clients.Live
{
    public class LiveOpenConnectClient : IOpenConnectClient
    {
        private IHttpClient _httpClient;

        public AppInfo AppInfo { get; private set; }

        public LiveOpenConnectClient(AppInfo appInfo)
            : this(appInfo, HttpClient.Instance)
        {
        }

        public LiveOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            _httpClient = httpClient;
        }

        public string GetAuthorizationUrl(AuthorizationUrlParameters parameters)
        {
            return new LoginUrlBuilder("https://oauth.live.com/authorize")
            {
                OtherParameters = parameters.OtherParameters
            }
            .Build(AppInfo, parameters.ResponseType, parameters.RedirectUri, parameters.Scope, parameters.Display);
        }

        public AccessTokenResponse GetAccessToken(AccessTokenRequestParameters parameters)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest("https://oauth.live.com/token", _httpClient)
            {
                Method = HttpMethod.Get
            };
            var response = request.GetResponse(AppInfo, parameters);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            return new LiveGetUserInfoRequest(_httpClient).GetResponse(AppInfo, parameters.AccessToken);
        }
    }
}
