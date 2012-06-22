using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenConnect.Providers.Tencent
{
    public class TencentAccessTokenRetriever : OAuthAccessTokenRetriever
    {
        public TencentAccessTokenRetriever(string apiPath)
            : base(apiPath)
        {
        }

        public TencentAccessTokenRetriever(string apiPath, IHttpClient httpClient)
            : base(apiPath, httpClient)
        {
        }

        protected override AccessToken ParseResponse(string response, DateTime startRequestTime)
        {
            var result = AccessTokenRequestResult.Parse(response);

            if (!result.IsValid)
                throw new ApiException("Invalid response when request access token: " + response + ".");

            return new AccessToken(result.Token, startRequestTime.AddSeconds(result.Expires), result.RefreshToken);
        }
    }
}
