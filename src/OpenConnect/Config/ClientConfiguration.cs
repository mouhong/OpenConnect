using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Config
{
    public class ClientConfiguration
    {
        public string Name { get; private set; }

        public string AppId { get; private set; }

        public string AppSecret { get; private set; }

        public string Scope { get; private set; }

        public string RedirectUri { get; private set; }

        public string Provider { get; private set; }

        public ClientConfiguration(string name, string appId, string appSecret, string scope, string redirectUri, string provider)
        {
            Require.NotNullOrEmpty(name, "name");
            Require.NotNullOrEmpty(appId, "appId");
            Require.NotNullOrEmpty(appSecret, "appSecret");
            Require.NotNullOrEmpty(redirectUri, "redirectUri");
            Require.NotNullOrEmpty(provider, "provider");

            Name = name;
            AppId = appId;
            AppSecret = appSecret;
            Scope = scope;
            RedirectUri = redirectUri;
            Provider = provider;
        }
    }
}
