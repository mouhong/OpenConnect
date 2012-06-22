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
        public ActionResult Success(string clientName, string code, string openid = null)
        {
            var client = OpenConnectUtil.ClientManager.Find(clientName);

            var state = Guid.NewGuid().ToString("N");

            var token = client.GetAccessToken(code, state);
            var user = client.GetUserInfo(token.Token, openid);

            ViewBag.ClientName = clientName;

            return View(user);
        }
    }
}
