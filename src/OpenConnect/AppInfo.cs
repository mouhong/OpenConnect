using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    /// <summary>
    /// The application information you retrieves from the open connect service provider.
    /// </summary>
    [Serializable]
    public class AppInfo
    {
        /// <summary>
        /// The application ID. Some providers use AppKey instead.
        /// </summary>
        public string AppId { get; private set; }

        /// <summary>
        /// The application secret key.
        /// </summary>
        public string AppSecret { get; private set; }

        /// <summary>
        /// The scope of resources to access. Multiple scopes are separated with comma.
        /// </summary>
        public string Scope { get; private set; }

        /// <summary>
        /// A callback uri for the authorization process.
        /// </summary>
        public string RedirectUri { get; private set; }

        public AppInfo(string appId, string appSecret, string scope, string redirectUri)
        {
            Require.NotNullOrEmpty(appId, "appId");
            Require.NotNullOrEmpty(appSecret, "appSecret");
            Require.NotNullOrEmpty(redirectUri, "redirectUri");

            AppId = appId;
            AppSecret = appSecret;
            Scope = scope;
            RedirectUri = redirectUri;
        }
    }
}
