using OpenConnect.Providers.Google;
using OpenConnect.Providers.Live;
using OpenConnect.Providers.Renren;
using OpenConnect.Providers.Sina;
using OpenConnect.Providers.Taobao;
using OpenConnect.Providers.Tencent.QQ;
using OpenConnect.Providers.Tencent.Weibo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenConnect.MvcExample.Utils
{
    public static class OpenConnectAccounts
    {
        static Dictionary<string, OpenConnectAccount> _accountsByName { get; set; }

        public static IEnumerable<OpenConnectAccount> Accounts
        {
            get
            {
                return _accountsByName.Values;
            }
        }

        static OpenConnectAccounts()
        {
            _accountsByName = new Dictionary<string, OpenConnectAccount>();

            _accountsByName.Add("QQ",
                new OpenConnectAccount
                {
                    AppInfo = new AppInfo("100238506", "0379c7b5e5f78aa7909f2238d3186893", null),
                    DisplayName = "QQ",
                    ProviderType = typeof(QQOpenConnectProvider)
                });

            _accountsByName.Add("Tencent Weibo",
                new OpenConnectAccount
                {
                    AppInfo = new AppInfo("801176853", "a8d4c7256c54b2a5be5c414d42ac5d70", "all"),
                    DisplayName = "Tencent Weibo",
                    ProviderType = typeof(TencentWeiboOpenConnectProvider)
                });

            _accountsByName.Add("Sina Weibo",
                new OpenConnectAccount
                {
                    AppInfo = new AppInfo("2841977476", "f8abbb8426b825822f81ef80bb648d08", null),
                    DisplayName = "Sina Weibo",
                    ProviderType = typeof(SinaWeiboOpenConnectProvider)
                });

            _accountsByName.Add("Renren",
                new OpenConnectAccount
                {
                    AppInfo = new AppInfo("d932b70a58d84905a66aa6b06e47377b", "30f63d25cff548649a51f73c952299b7", null),
                    DisplayName = "Renren",
                    ProviderType = typeof(RenrenOpenConnectProvider)
                });

            _accountsByName.Add("Live",
                new OpenConnectAccount
                {
                    AppInfo = new AppInfo("0000000040080F13", "yIs33isum4ZmnahwPbyGNbnJY4RoiyvS", "wl.signin,wl.basic"),
                    DisplayName = "Live",
                    ProviderType = typeof(LiveOpenConnectProvider)
                });

            _accountsByName.Add("Google",
                new OpenConnectAccount
                {
                    AppInfo = new AppInfo("352501794367.apps.googleusercontent.com", "lQ8ShnALbvYfM0lbQ0vUzLCv", "https://www.googleapis.com/auth/userinfo.profile"),
                    DisplayName = "Google",
                    ProviderType = typeof(GoogleOpenConnectProvider)
                });

            _accountsByName.Add("Taobao",
                new OpenConnectAccount
                {
                    AppInfo = new AppInfo("12412746", "0a5fc2c8beef294900e1fcf7bda46af2", null),
                    DisplayName = "Taobao",
                    ProviderType = typeof(TaobaoOpenConnectProvider)
                });
        }

        public static OpenConnectAccount GetAccount(string name)
        {
            return _accountsByName[name];
        }
    }

    public class OpenConnectAccount
    {
        public AppInfo AppInfo { get; set; }

        public string DisplayName { get; set; }

        public Type ProviderType { get; set; }
    }
}