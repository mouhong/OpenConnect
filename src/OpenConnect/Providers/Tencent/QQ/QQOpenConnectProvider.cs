using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent.QQ
{
    public class QQOpenConnectProvider : IOpenConnectProvider
    {
        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new OAuthAuthorizationUrlBuilder("https://graph.qq.com/oauth2.0/authorize");
        }

        public IGetAccessTokenRequest GetAccessTokenRetriever()
        {
            return new TencentGetAccessTokenRequest("https://graph.qq.com/oauth2.0/token");
        }

        public IGetUserInfoRequest GetUserInfoRetriever()
        {
            return new QQGetUserInfoRequest();
        }
    }
}
