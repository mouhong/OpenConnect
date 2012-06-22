using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Providers;

namespace OpenConnect
{
    public class OpenConnectClient
    {
        private ILoginUrlBuilder _urlBuilder;
        private IGetAccessTokenRequest _getAccessTokenRequest;
        private IGetUserInfoRequest _getUserInfoRequest;

        public AppInfo AppInfo { get; private set; }

        public OpenConnectClient(AppInfo appInfo, IOpenConnectProvider provider)
        {
            Require.NotNull(appInfo, "appInfo");
            Require.NotNull(provider, "provider");

            AppInfo = appInfo;
            _urlBuilder = provider.GetAuthorizationUrlBuilder();
            _getAccessTokenRequest = provider.CreateGetAccessTokenRequest();
            _getUserInfoRequest = provider.CreateGetUserInfoRequest();
        }

        public string GetLoginUrl(string display, ResponseType responseType)
        {
            return _urlBuilder.Build(AppInfo, display, responseType);
        }

        public AccessToken GetAccessToken(string authCode, string state = null)
        {
            return _getAccessTokenRequest.GetResponse(AppInfo, authCode, state);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId = null)
        {
            return _getUserInfoRequest.GetResponse(AppInfo, accessToken, userId);
        }
    }
}
