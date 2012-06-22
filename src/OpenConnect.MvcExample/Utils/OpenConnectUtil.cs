using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenConnect.Providers.QQ;
using OpenConnect.Providers.Weibo;
using OpenConnect.Providers.Renren;
using OpenConnect.Providers.Live;
using OpenConnect.Providers.Google;

namespace OpenConnect.MvcExample.Utils
{
    public class OpenConnectUtil
    {
        public static OpenConnectClientManager ClientManager;

        static OpenConnectUtil()
        {
            var manager = new OpenConnectClientManager();

            manager.Add("QQ", new OpenConnectClient(
                new AppInfo("100238506", "0379c7b5e5f78aa7909f2238d3186893", null, GetRedirectUri("QQ")),
                new QQOpenConnectProvider()));

            manager.Add("Sina Weibo", new OpenConnectClient(
                new AppInfo("2841977476", "f8abbb8426b825822f81ef80bb648d08", null, GetRedirectUri("Sina Weibo")),
                new SinaWeiboOpenConnectProvider()));

            manager.Add("Renren", new OpenConnectClient(
                new AppInfo("d932b70a58d84905a66aa6b06e47377b", "30f63d25cff548649a51f73c952299b7", null, GetRedirectUri("Renren")),
                new RenrenOpenConnectProvider()));

            manager.Add("Live", new OpenConnectClient(
                new AppInfo("0000000040080F13", "yIs33isum4ZmnahwPbyGNbnJY4RoiyvS", "wl.signin,wl.basic", GetRedirectUri("Live")),
                new LiveOpenConnectProvider()));

            manager.Add("Google", new OpenConnectClient(
                new AppInfo("352501794367.apps.googleusercontent.com", "lQ8ShnALbvYfM0lbQ0vUzLCv", "https://www.googleapis.com/auth/userinfo.profile", GetRedirectUri("Google")),
                new GoogleOpenConnectProvider()));

            ClientManager = manager;
        }

        static string GetRedirectUri(string clientName)
        {
            return "http://test.sigcms.com/LoginCallback/Success?clientName=" + clientName;
        }
    }
}