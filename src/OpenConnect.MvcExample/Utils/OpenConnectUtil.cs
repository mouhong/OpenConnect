using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenConnect.Clients.Tencent.QQ;
using OpenConnect.Clients.Sina;
using OpenConnect.Clients.Renren;
using OpenConnect.Clients.Live;
using OpenConnect.Clients.Google;
using OpenConnect.Clients.Tencent.Weibo;
using OpenConnect.Clients.Taobao;

namespace OpenConnect.MvcExample.Utils
{
    public class OpenConnectUtil
    {
        public static OpenConnectClientManager ClientManager;

        static OpenConnectUtil()
        {
            var manager = new OpenConnectClientManager();

            manager.Add("QQ", new QQOpenConnectClient(
                new AppInfo("100238506", "0379c7b5e5f78aa7909f2238d3186893", null, GetRedirectUri("QQ"))));

            manager.Add("Tencent Weibo", new TencentWeiboOpenConnectClient(
                new AppInfo("801176853", "a8d4c7256c54b2a5be5c414d42ac5d70", "all", GetRedirectUri("Tencent Weibo"))));

            manager.Add("Sina Weibo", new SinaWeiboOpenConnectClient(
                new AppInfo("2841977476", "f8abbb8426b825822f81ef80bb648d08", null, GetRedirectUri("Sina Weibo"))));

            manager.Add("Renren", new RenrenOpenConnectClient(
                new AppInfo("d932b70a58d84905a66aa6b06e47377b", "30f63d25cff548649a51f73c952299b7", null, GetRedirectUri("Renren"))));

            manager.Add("Live", new LiveOpenConnectClient(
                new AppInfo("0000000040080F13", "yIs33isum4ZmnahwPbyGNbnJY4RoiyvS", "wl.signin,wl.basic", GetRedirectUri("Live"))));

            manager.Add("Google", new GoogleOpenConnectClient(
                new AppInfo("352501794367.apps.googleusercontent.com", "lQ8ShnALbvYfM0lbQ0vUzLCv", "https://www.googleapis.com/auth/userinfo.profile", GetRedirectUri("Google"))));

            manager.Add("Taobao", new TaobaoOpenConnectClient(
                new AppInfo("12412746", "0a5fc2c8beef294900e1fcf7bda46af2", null, GetRedirectUri("Taobao"))));

            ClientManager = manager;
        }

        static string GetRedirectUri(string clientName)
        {
            return "http://test.sigcms.com/LoginCallback?clientName=" + clientName;
        }
    }
}