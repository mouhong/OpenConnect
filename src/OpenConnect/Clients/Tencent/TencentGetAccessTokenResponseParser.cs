using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenConnect.Clients.Tencent
{
    static class TencentGetAccessTokenResponseParser
    {
        public static AccessTokenResponse Parse(string response, DateTime startRequestTime)
        {
            var result = AccessTokenRequestResult.Parse(response);

            if (!result.IsValid)
                throw new ApiException("Invalid response when request access token: " + response + ".");

            return new AccessTokenResponse(result.Token, startRequestTime.AddSeconds(result.Expires), result.RefreshToken, null);
        }
    }
}
