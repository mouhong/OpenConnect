using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public interface IGetAccessTokenRequest
    {
        AccessToken GetResponse(AppInfo appInfo, string authCode, string state);
    }
}
