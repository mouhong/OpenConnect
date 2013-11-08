using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public class AuthorizationParameters
    {
        public AppInfo AppInfo { get; set; }

        public ResponseType ResponseType { get; set; }

        public string RedirectUri { get; set; }

        public string Scope { get; set; }

        public string Display { get; set; }

        public AuthorizationParameters(AppInfo appInfo, ResponseType responseType, string redirectUri)
        {
            AppInfo = appInfo;
            ResponseType = responseType;
            RedirectUri = redirectUri;
        }
    }
}
