using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Providers;

namespace OpenConnect
{
    public class OpenConnectClient
    {
        private IAuthorizationUrlBuilder _urlBuilder;
        private IAccessTokenRetriever _accessTokenRetriever;
        private IUserInfoRetriever _userInfoRetriever;

        public string Name { get; private set; }

        public AppInfo AppInfo { get; private set; }

        public OpenConnectClient(string name, AppInfo appInfo, IOpenConnectProvider provider)
        {
            Check.RequireNotNullOrEmpty(name, "name");
            Check.RequireNotNull(appInfo, "appInfo");
            Check.RequireNotNull(provider, "provider");

            Name = name;
            AppInfo = appInfo;
            _urlBuilder = provider.GetAuthorizationUrlBuilder();
            _accessTokenRetriever = provider.GetAccessTokenRetriever();
            _userInfoRetriever = provider.GetUserInfoRetriever();
        }

        public string GetAuthUrl(string display, ResponseType responseType)
        {
            return _urlBuilder.Build(AppInfo, display, responseType);
        }

        public AccessToken GetAccessToken(string authCode, string state)
        {
            return _accessTokenRetriever.Retrieve(AppInfo, authCode, state);
        }

        public AccessToken RefreshAccessToken(string refreshToken)
        {
            return _accessTokenRetriever.Refresh(AppInfo, refreshToken);
        }

        public UserInfo GetUserInfo(string accessToken)
        {
            return _userInfoRetriever.Retrieve(AppInfo, accessToken);
        }
    }
}
