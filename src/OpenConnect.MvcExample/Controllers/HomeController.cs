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
            var links = new List<LoginLink>();

            foreach (var client in OpenConnectHelper.AllClients)
            {
                var link = new LoginLink
                {
                    Text = "Login with " + client.Name,
                    Url = client.GetAuthUrl(null, ResponseType.Code)
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
