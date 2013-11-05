using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenConnect.MvcExample.Models;
using OpenConnect.MvcExample.Utils;

namespace OpenConnect.MvcExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var links = new List<LoginLink>();

            foreach (var account in OpenConnectAccounts.Accounts)
            {
                var provider = (IOpenConnectProvider)Activator.CreateInstance(account.ProviderType);
                var authUriBuilder = provider.GetAuthorizationUrlBuilder();
                var authUrl = authUriBuilder.GetAuthorizationUri(new AuthorizationParameters(ResponseType.Code, "http://test.sigcms.com/LoginCallback?clientName=" + account.DisplayName), account.AppInfo);

                var link = new LoginLink
                {
                    ImageUrl = "/Content/Images/connect-" + account.DisplayName.Replace(' ', '-') + ".png",
                    NavigateUrl = authUrl
                };

                links.Add(link);
            }
            
            return View(links);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
