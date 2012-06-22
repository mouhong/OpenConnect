using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenConnect.Providers.QQ
{
    public class QQAccessTokenRetriever : StandardAccessTokenRetriever
    {
        public QQAccessTokenRetriever()
            : base("https://graph.qq.com/oauth2.0/token")
        {
        }

        public QQAccessTokenRetriever(IHttpClient httpClient)
            : base("https://graph.qq.com/oauth2.0/token", httpClient)
        {
        }

        protected override AccessToken ParseResponse(string response, DateTime startRequestTime)
        {
            var result = AccessTokenRequestResult.Parse(response);

            if (!result.IsValid)
                throw new ApiException("Invalid response when request access token: " + response + ".");

            return new AccessToken(result.Token, startRequestTime.AddSeconds(result.Expires), null);
        }
    }
}
