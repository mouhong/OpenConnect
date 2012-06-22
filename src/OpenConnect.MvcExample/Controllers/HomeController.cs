using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenConnect.MvcExample.Models;

namespace OpenConnect.MvcExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var links = new List<LoginLink>()
            {
                new LoginLink {
                    Text = "QQ",
                    Url = OpenConnectUtil.ClientManager.Find("QQ").GetAuthUrl(null, ResponseType.Code)
                },
                new LoginLink {
                    Text = "Sina Weibo",
                    Url = OpenConnectUtil.ClientManager.Find("Sina Weibo").GetAuthUrl(null, ResponseType.Code)
                }
            };

            return View(links);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
