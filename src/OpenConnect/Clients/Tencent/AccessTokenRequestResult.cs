using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenConnect.Clients.Tencent
{
    class AccessTokenRequestResult
    {
        public bool IsValid
        {
            get
            {
                return !String.IsNullOrEmpty(Token);
            }
        }

        public string Token { get; private set; }

        public string RefreshToken { get; private set; }

        public string Name { get; set; }

        public string Nick { get; set; }

        public int Expires { get; private set; }

        private AccessTokenRequestResult(string tokenResult)
        {
            ParseInput(tokenResult);
        }

        public static AccessTokenRequestResult Parse(string tokenResult)
        {
            return new AccessTokenRequestResult(tokenResult);
        }

        private void ParseInput(string tokenResult)
        {
            var nv = new NameValueCollection();

            var keyValuePairs = tokenResult.Split('&');
            
            foreach (var keyValuePair in keyValuePairs)
            {
                var parts = keyValuePair.Split('=');
                if (parts.Length == 2)
                {
                    nv.Add(parts[0], parts[1]);
                }
            }

            Token = nv["access_token"];
            RefreshToken = nv["refresh_token"];
            Name = nv["name"];
            Nick = nv["nick"];

            var expiresIn = nv["expires_in"];
            if (!String.IsNullOrEmpty(expiresIn))
            {
                Expires = Convert.ToInt32(expiresIn);
            }
        }
    }
}
