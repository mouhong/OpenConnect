using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Weibo
{
    public class SinaWeiboOpenConnectProvider : IOpenConnectProvider
    {
        public SinaWeiboOpenConnectProvider()
        {
        }

        public virtual ILoginUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new StandardLoginUrlBuilder("https://api.weibo.com/oauth2/authorize");
        }

        public virtual IGetAccessTokenRequest CreateGetAccessTokenRequest()
        {
            return new StandardGetAccessTokenRequest("https://api.weibo.com/oauth2/access_token")
            {
                Method = HttpMethod.Post
            };
        }

        public virtual IGetUserInfoRequest CreateGetUserInfoRequest()
        {
            return new SinaWeiboGetUserInfoRequest();
        }
    }
}
