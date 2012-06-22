using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Providers;
using OpenConnect.Providers.Google;
using OpenConnect.Providers.Live;
using OpenConnect.Providers.QQ;
using OpenConnect.Providers.Renren;
using OpenConnect.Providers.Weibo;

namespace OpenConnect
{
    public static class OpenConnectProviderFactories
    {
        public static IOpenConnectProviderFactory Current;

        static OpenConnectProviderFactories()
        {
            var factory = new OpenConnectProviderFactory();

            factory.Register(typeof(GoogleOpenConnectProvider).FullName, () => new GoogleOpenConnectProvider());
            factory.Register(typeof(LiveOpenConnectProvider).FullName, () => new LiveOpenConnectProvider());
            factory.Register(typeof(QQOpenConnectProvider).FullName, () => new QQOpenConnectProvider());
            factory.Register(typeof(RenrenOpenConnectProvider).FullName, () => new RenrenOpenConnectProvider());
            factory.Register(typeof(SinaWeiboOpenConnectProvider).FullName, () => new SinaWeiboOpenConnectProvider());

            Current = factory;
        }
    }
}
