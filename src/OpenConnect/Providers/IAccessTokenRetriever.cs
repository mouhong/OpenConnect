using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public interface IAccessTokenRetriever
    {
        AccessToken Retrieve(AppInfo appInfo, string authCode, string state);

        AccessToken Refresh(AppInfo appInfo, string refreshToken);
    }
}
