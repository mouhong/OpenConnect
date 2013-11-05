using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OpenConnect
{
    public class AuthorizationCallbackParser : IAuthorizationCallbackParser
    {
        public AuthorizationResult Parse(HttpRequestBase callbackRequest)
        {
            return new AuthorizationResult
            {
                Code = callbackRequest["code"],
                UserId = callbackRequest["openid"]
            };
        }
    }
}
