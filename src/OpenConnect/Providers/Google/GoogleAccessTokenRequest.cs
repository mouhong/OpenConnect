using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Google
{
    public class GoogleAccessTokenRequest : AccessTokenRequest
    {
        public GoogleAccessTokenRequest(IHttpClient httpClient)
            : base("https://accounts.google.com/o/oauth2/token", httpClient)
        {
        }

        public override AccessTokenResponse GetAccessToken(AccessTokenRequestParameters parameters)
        {
            // state must be null in google
            parameters.State = null;

            return base.GetAccessToken(parameters);
        }
    }
}
