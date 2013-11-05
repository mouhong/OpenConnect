using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public class AccessTokenRequestParameters
    {
        public AppInfo AppInfo { get; set; }

        public AuthorizationResult AuthorizationResult { get; set; }

        public string RedirectUri { get; set; }

        public string State { get; set; }

        public AccessTokenRequestParameters(AppInfo appInfo, AuthorizationResult authorizationResult, string reidrectUri)
        {
            AppInfo = appInfo;
            AuthorizationResult = authorizationResult;
            RedirectUri = reidrectUri;
        }
    }
}
