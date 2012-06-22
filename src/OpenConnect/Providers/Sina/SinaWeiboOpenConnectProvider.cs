using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Weibo
{
    public class SinaWeiboOpenConnectProvider : IOpenConnectProvider
    {
        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new StandardAuthorizationUrlBuilder("https://api.weibo.com/oauth2/authorize");
        }

        public IAccessTokenRetriever GetAccessTokenRetriever()
        {
            return new StandardAccessTokenRetriever("https://api.weibo.com/oauth2/access_token")
            {
                Method = HttpMethod.Post
            };
        }

        public IUserInfoRetriever GetUserInfoRetriever()
        {
            return new SinaWeiboUserInfoRetriever();
        }
    }
}
