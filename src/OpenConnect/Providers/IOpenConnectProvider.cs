using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public interface IOpenConnectProvider
    {
        IAuthorizationUrlBuilder GetAuthorizationUrlBuilder();

        IGetAccessTokenRequest GetAccessTokenRetriever();

        IGetUserInfoRequest GetUserInfoRetriever();
    }
}
