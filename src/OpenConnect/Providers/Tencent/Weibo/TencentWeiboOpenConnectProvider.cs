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

        public IGetAccessTokenRequest GetAccessTokenRetriever()
        {
            return new TencentGetAccessTokenRequest("https://open.t.qq.com/cgi-bin/oauth2/access_token");
        }

        public IGetUserInfoRequest GetUserInfoRetriever()
        {
            return new TencentWeiboGetUserInfoRequest();
        }
    }
}
