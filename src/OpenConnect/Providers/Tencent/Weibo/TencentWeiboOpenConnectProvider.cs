using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent.Weibo
{
    public class TencentWeiboOpenConnectProvider : IOpenConnectProvider
    {
        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new OAuthAuthorizationUrlBuilder("https://open.t.qq.com/cgi-bin/oauth2/authorize");
        }

        public IAccessTokenRetriever GetAccessTokenRetriever()
        {
            return new TencentAccessTokenRetriever("https://open.t.qq.com/cgi-bin/oauth2/access_token");
        }

        public IUserInfoRetriever GetUserInfoRetriever()
        {
            return new TencentWeiboUserInfoRetriever();
        }
    }
}
