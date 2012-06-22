using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent.QQ
{
    public class QQOpenConnectProvider : IOpenConnectProvider
    {
        public QQOpenConnectProvider()
        {
        }

        public virtual ILoginUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new StandardLoginUrlBuilder("https://graph.qq.com/oauth2.0/authorize");
        }

        public virtual IGetAccessTokenRequest CreateGetAccessTokenRequest()
        {
            return new TencentGetAccessTokenRequest("https://graph.qq.com/oauth2.0/token");
        }

        public virtual IGetUserInfoRequest CreateGetUserInfoRequest()
        {
            return new QQGetUserInfoRequest();
        }
    }
}
