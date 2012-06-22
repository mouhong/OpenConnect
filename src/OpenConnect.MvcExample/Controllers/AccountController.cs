using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenConnect.MvcExample.Models;

namespace OpenConnect.MvcExample.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult QQLoginSuccess(string code)
        {
            return View("LoginSuccess", GetUserInfo("QQ", code));
        }

        public ActionResult WeiboLoginSuccess(string code)
        {
            return View("LoginSuccess", GetUserInfo("Sina Weibo", code));
        }

        public ActionResult LiveLoginSuccess(string code)
        {
            return View("LoginSuccess", GetUserInfo("Live", code));
        }

        public ActionResult RenrenLoginSuccess(string code)
        {
            return View("LoginSuccess", GetUserInfo("Renren", code));
        }

        private UserInfo GetUserInfo(string clientName, string code)
        {
            var client = OpenConnectUtil.ClientManager.Find(clientName);

            var state = Guid.NewGuid().ToString("N");

            var token = client.GetAccessToken(code, state);
            var user = client.GetUserInfo(token.Token);

            return user;
        }
    }
}
