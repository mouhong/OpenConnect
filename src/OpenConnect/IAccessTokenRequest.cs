using OpenConnect.Providers;
using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public interface IAccessTokenRequest
    {
        AccessTokenResponse GetAccessToken(AccessTokenRequestParameters parameters);
    }
}
