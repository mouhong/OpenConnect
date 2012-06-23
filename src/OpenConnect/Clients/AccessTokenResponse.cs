using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Clients
{
    public class AccessTokenResponse
    {
        public string AccessToken { get; private set; }

        public DateTime AccessTokenExpireTime { get; private set; }

        public string RefreshToken { get; private set; }

        public DateTime? RefreshTokenExpireTime { get; private set; }

        public string UserId { get; set; }

        public string UserNickName { get; set; }

        public AccessTokenResponse(string token, DateTime expireTime, string refreshToken, DateTime? refershTokenExpireTime)
        {
            Require.NotNullOrEmpty(token, "token");

            AccessToken = token;
            AccessTokenExpireTime = expireTime;
            RefreshToken = refreshToken;
            RefreshTokenExpireTime = refershTokenExpireTime;
        }
    }
}
