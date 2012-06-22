using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.QQ
{
    public class QQOpenConnectProvider : IOpenConnectProvider
    {
        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new StandardAuthorizationUrlBuilder("https://graph.qq.com/oauth2.0/authorize");
        }

        public IAccessTokenRetriever GetAccessTokenRetriever()
        {
            return new QQAccessTokenRetriever();
        }

        public IUserInfoRetriever GetUserInfoRetriever()
        {
            return new QQUserInfoRetriever();
        }
    }
}
