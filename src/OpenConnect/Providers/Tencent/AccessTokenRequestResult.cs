using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenConnect.Providers.Tencent
{
    class AccessTokenRequestResult
    {
        private static readonly Regex _requestResultPattern = new Regex(@"^access_token=([^&]+)&expires_in=(\d+)(&refresh_token=([^&]+))?", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public bool IsValid { get; private set; }

        public string Token { get; private set; }

        public string RefreshToken { get; private set; }

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
                Token = match.Groups[1].Value;
                Expires = Convert.ToInt32(match.Groups[2].Value);

                if (match.Groups.Count > 4)
                {
                    RefreshToken = match.Groups[4].Value;
                }
            }
        }
    }
}
