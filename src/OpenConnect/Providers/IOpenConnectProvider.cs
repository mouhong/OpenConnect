using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    /// <summary>
    /// Provides an interface for different open connect provider implemenations.
    /// </summary>
    public interface IOpenConnectProvider
    {
        /// <summary>
        /// Gets the <see cref="T:OpenConnect.Providers.ILoginUrlBuilder"/> implementation for login url building.
        /// </summary>
        /// <returns></returns>
        ILoginUrlBuilder GetLoginUrlBuilder();

        /// <summary>
        /// Creates the <see cref="T:OpenConnect.Providers.IGetAccessTokenRequest"/> implementation for retrieving access token.
        /// </summary>
        /// <returns></returns>
        IGetAccessTokenRequest CreateGetAccessTokenRequest();

        /// <summary>
        /// Creates the <see cref="T:OpenConnect.Providers.IGetUserInfoRequest"/> implementation for retrieving user information.
        /// </summary>
        /// <returns></returns>
        IGetUserInfoRequest CreateGetUserInfoRequest();
    }
}
