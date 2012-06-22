using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public class AccessToken
    {
        public string Token { get; private set; }

        public DateTime ExpireTime { get; private set; }

        public string RefreshToken { get; private set; }

        public AccessToken(string token, DateTime expireTime, string refreshToken)
        {
            Require.NotNullOrEmpty(token, "token");

            Token = token;
            ExpireTime = expireTime;
            RefreshToken = refreshToken;
        }
    }
}
