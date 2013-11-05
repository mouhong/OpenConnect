using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OpenConnect
{
    public interface IAuthorizationCallbackParser
    {
        AuthorizationResult Parse(HttpRequestBase callbackRequest);
    }
}
