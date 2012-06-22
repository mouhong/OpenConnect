using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    [Serializable]
    public class AppInfo
    {
        public string AppId { get; private set; }

        public string AppSecret { get; private set; }

        public string Scope { get; private set; }

        public string RedirectUri { get; private set; }

        public AppInfo(string appId, string appSecret, string scope, string redirectUri)
        {
            Check.RequireNotNullOrEmpty(appId, "appId");
            Check.RequireNotNullOrEmpty(appSecret, "appSecret");
            Check.RequireNotNullOrEmpty(redirectUri, "redirectUri");

            AppId = appId;
            AppSecret = appSecret;
            Scope = scope;
            RedirectUri = redirectUri;
        }
    }
}
