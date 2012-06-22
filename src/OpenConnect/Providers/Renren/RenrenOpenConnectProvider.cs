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
            return new StandardAuthorizationUrlBuilder("https://graph.renren.com/oauth/authorize");
        }

        public IAccessTokenRetriever GetAccessTokenRetriever()
        {
            return new StandardAccessTokenRetriever("https://graph.renren.com/oauth/token");
        }

        public IUserInfoRetriever GetUserInfoRetriever()
        {
            return new RenrenUserInfoRetriever();
        }
    }
}
