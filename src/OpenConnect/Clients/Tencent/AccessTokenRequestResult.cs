using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenConnect.Clients.Tencent
{
    class AccessTokenRequestResult
    {
        private static readonly Regex _requestResultPattern = new Regex(@"^access_token=(?<accessToken>[^&]+)&expires_in=(?<expiresIn>\d+)(&refresh_token=(?<refreshToken>[^&]+))?(&name=(?<name>[^$]+))?(&nick=(?<nick>[^$]+))", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public bool IsValid { get; private set; }

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
            var match = _requestResultPattern.Match(tokenResult);

            IsValid = match.Success;

            if (match.Success)
            {
                Token = match.Groups["accessToken"].Value;
                Expires = Convert.ToInt32(match.Groups["expiresIn"].Value);

                RefreshToken = match.Groups["refreshToken"].Value;

                Name = match.Groups["name"].Value;
                Nick = match.Groups["nick"].Value;
            }
        }
    }
}
