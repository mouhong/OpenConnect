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
        public string DefaultScope { get; set; }

        public AppInfo(string appId, string appSecret)
            : this(appId, appSecret, null)
        {
        }

        public AppInfo(string appId, string appSecret, string defaultScope)
        {
            Require.NotNullOrEmpty(appId, "appId");
            Require.NotNullOrEmpty(appSecret, "appSecret");

            AppId = appId;
            AppSecret = appSecret;
            DefaultScope = defaultScope;
        }
    }
}
