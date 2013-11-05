using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public interface IOpenConnectProvider
    {
        IAuthorizationUrlBuilder GetAuthorizationUrlBuilder();

        IAuthorizationCallbackParser GetAuthorizationCallbackParser();

        IAccessTokenRequest CreateAccessTokenRequest();

        IUserInfoRequest CreateUserInfoRequest();
    }
}
