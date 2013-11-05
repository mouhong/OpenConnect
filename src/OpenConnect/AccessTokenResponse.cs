using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public class AccessTokenResponse
    {
        public string AccessToken { get; set; }

        public DateTime AccessTokenExpireTime { get; set; }

        public string RefreshToken { get; set; }

        public DateTime? RefreshTokenExpireTime { get; set; }

        public string UserId { get; set; }
    }
}
