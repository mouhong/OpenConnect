using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public interface IAuthorizationUrlBuilder
    {
        string GetAuthorizationUri(AuthorizationParameters request, AppInfo appInfo);
    }
}
