using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public class AuthorizationParameters
    {
        public ResponseType ResponseType { get; set; }

        public string RedirectUri { get; set; }

        public string Scope { get; set; }

        public string Display { get; set; }

        public AuthorizationParameters(ResponseType responseType, string redirectUri)
        {
            ResponseType = responseType;
            RedirectUri = redirectUri;
        }
    }
}
