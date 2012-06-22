using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenConnect.Config;
using System.IO;

namespace OpenConnect.MvcExample.Models
{
    public class OpenConnectHelper
    {
        public static readonly OpenConnectClientManager Manager;

        public static IEnumerable<OpenConnectClient> AllClients
        {
            get
            {
                return Manager.AllClients;
            }
        }

        static OpenConnectHelper()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\openconnect.config");
            var cfg = OpenConnectConfiguration.From(path);
            Manager = OpenConnectClientManager.BuildFrom(cfg);
        }

        public static OpenConnectClient FindClient(string name)
        {
            return Manager.FindClient(name);
        }
    }
}