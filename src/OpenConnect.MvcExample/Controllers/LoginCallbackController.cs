using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenConnect.MvcExample.Utils;

namespace OpenConnect.MvcExample.Controllers
{
    public class LoginCallbackController : Controller
    {
        public ActionResult Index(string clientName)
        {
            var account = OpenConnectAccounts.GetAccount(clientName);
            var provider = (IOpenConnectProvider)Activator.CreateInstance(account.ProviderType);

            var state = Guid.NewGuid().ToString("N");

            var authResponse = provider.GetAuthorizationCallbackParser().Parse(Request);
            var tokenResponse = provider.CreateAccessTokenRequest()
                                        .GetAccessToken(new AccessTokenRequestParameters(account.AppInfo, authResponse, "http://test.sigcms.com/LoginCallback?clientName=" + clientName));
            var user = provider.CreateUserInfoRequest()
                               .GetUserInfo(new UserInfoRequestParameters(account.AppInfo, authResponse, tokenResponse));

            ViewBag.ClientName = clientName;

            return View(user);
        }
    }
}
