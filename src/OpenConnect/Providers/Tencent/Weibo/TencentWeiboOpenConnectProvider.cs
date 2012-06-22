using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent.Weibo
{
    public class TencentWeiboOpenConnectProvider : IOpenConnectProvider
    {
        public TencentWeiboOpenConnectProvider()
        {
        }

        public virtual ILoginUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new StandardLoginUrlBuilder("https://open.t.qq.com/cgi-bin/oauth2/authorize");
        }

        public virtual IGetAccessTokenRequest CreateGetAccessTokenRequest()
        {
            return new TencentGetAccessTokenRequest("https://open.t.qq.com/cgi-bin/oauth2/access_token");
        }

        public virtual IGetUserInfoRequest CreateGetUserInfoRequest()
        {
            return new TencentWeiboGetUserInfoRequest();
        }
    }
}
