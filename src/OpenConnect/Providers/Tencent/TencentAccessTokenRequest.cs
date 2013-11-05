using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent
{
    public class TencentAccessTokenRequest : AccessTokenRequest
    {
        public TencentAccessTokenRequest(string apiPath, IHttpClient httpClient)
            : base(apiPath, httpClient)
        {
        }

        protected override AccessTokenResponse ParseAccessTokenResponse(string responseText, AccessTokenRequestParameters request)
        {
            var result = AccessTokenRequestResult.Parse(responseText);

            if (!result.IsValid)
                throw new ApiException("Invalid response when request access token: " + responseText + ".");

            return new TencentAccessTokenResponse
            {
                AccessToken = result.Token,
                AccessTokenExpireTime = DateTime.Now.AddSeconds(result.Expires),
                RefreshToken = result.RefreshToken,
                UserName = result.Name
            };
        }
    }
}
