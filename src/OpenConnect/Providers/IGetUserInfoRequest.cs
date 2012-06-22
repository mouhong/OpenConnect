using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    /// <summary>
    /// Represents a API request for retrieving user information.
    /// </summary>
    public interface IGetUserInfoRequest
    {
        /// <summary>
        /// Retrieves user information from the API server.
        /// </summary>
        /// <param name="appInfo">The application information.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="userId">The user id. Most providers do not require this. Set null if it's not required by the provider.</param>
        /// <returns>An <see cref="OpenConnect.IUserInfo"/> implementation containing the user information.</returns>
        IUserInfo GetResponse(AppInfo appInfo, string accessToken, string userId);
    }
}
