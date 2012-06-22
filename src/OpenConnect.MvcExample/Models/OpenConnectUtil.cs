using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenConnect.Providers.QQ;
using OpenConnect.Providers.Weibo;

namespace OpenConnect.MvcExample.Models
{
    public class OpenConnectUtil
    {
        public static OpenConnectClientManager ClientManager;

        static OpenConnectUtil()
        {
            var manager = new OpenConnectClientManager();

            manager.Add("QQ", new OpenConnectClient(
                new AppInfo("100238506", "0379c7b5e5f78aa7909f2238d3186893", null, "http://test.sigcms.com/Account/QQLoginSuccess"),
                new QQOpenConnectProvider()));

            manager.Add("Sina Weibo", new OpenConnectClient(
                new AppInfo("2841977476", "f8abbb8426b825822f81ef80bb648d08", null, "http://test.sigcms.com/Account/WeiboLoginSuccess"),
                new SinaWeiboOpenConnectProvider()));

            ClientManager = manager;
        }
    }
}