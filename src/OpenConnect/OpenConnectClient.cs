using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Providers;

namespace OpenConnect
{
    /// <summary>
    /// Reprensents a client that sents open connect API requests.
    /// </summary>
    public class OpenConnectClient
    {
        private ILoginUrlBuilder _urlBuilder;
        private IGetAccessTokenRequest _getAccessTokenRequest;
        private IGetUserInfoRequest _getUserInfoRequest;

        public AppInfo AppInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="T:OpenConnect.OpenConnectClient"/> class.
        /// </summary>
        /// <param name="appInfo">The application information.</param>
        /// <param name="provider">The underlying open connect provider implementaiton.</param>
        public OpenConnectClient(AppInfo appInfo, IOpenConnectProvider provider)
        {
            Require.NotNull(appInfo, "appInfo");
            Require.NotNull(provider, "provider");

            AppInfo = appInfo;
            _urlBuilder = provider.GetLoginUrlBuilder();
            _getAccessTokenRequest = provider.CreateGetAccessTokenRequest();
            _getUserInfoRequest = provider.CreateGetUserInfoRequest();
        }

        /// <summary>
        /// Constructs the login url with the specified display mode and response type.
        /// </summary>
        /// <param name="display">The display mode. Different open connect providers provide different display modes. Set null to use the default display mode.</param>
        /// <param name="responseType">The excepted response type.</param>
        /// <returns>The login url.</returns>
        public string BuildLoginUrl(string display, ResponseType responseType)
        {
            return _urlBuilder.Build(AppInfo, display, responseType);
        }

        /// <summary>
        /// Retrieves access token with received authorization code.
        /// </summary>
        /// <param name="authCode">The authorization code received in the authorization process.</param>
        /// <param name="state">A value to prevent the CSRF attack. It's not required.</param>
        /// <returns>The access token.</returns>
        public AccessToken RetrieveAccessToken(string authCode, string state = null)
        {
            return _getAccessTokenRequest.GetResponse(AppInfo, authCode, state);
        }

        /// <summary>
        /// Retrieves user information with received access token.
        /// </summary>
        /// <param name="accessToken">The access token received from the authorization server.</param>
        /// <param name="userId">The user id. Most providers do not require this. Set null if it's not needed.</param>
        /// <returns>The user information.</returns>
        public IUserInfo RetrieveUserInfo(string accessToken, string userId = null)
        {
            return _getUserInfoRequest.GetResponse(AppInfo, accessToken, userId);
        }
    }
}
