using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Renren
{
    public class RenrenOpenConnectProvider : IOpenConnectProvider
    {
        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new OAuthAuthorizationUrlBuilder("https://graph.renren.com/oauth/authorize");
        }

        public IGetAccessTokenRequest GetAccessTokenRetriever()
        {
            return new OAuthGetAccessTokenRequest("https://graph.renren.com/oauth/token");
        }

        public IGetUserInfoRequest GetUserInfoRetriever()
        {
            return new RenrenGetUserInfoRequest();
        }
    }
}
