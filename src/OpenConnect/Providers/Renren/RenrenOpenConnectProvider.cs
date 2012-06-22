using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Renren
{
    public class RenrenOpenConnectProvider : IOpenConnectProvider
    {
        public RenrenOpenConnectProvider()
        {
        }

        public virtual ILoginUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new StandardLoginUrlBuilder("https://graph.renren.com/oauth/authorize");
        }

        public virtual IGetAccessTokenRequest CreateGetAccessTokenRequest()
        {
            return new StandardGetAccessTokenRequest("https://graph.renren.com/oauth/token");
        }

        public virtual IGetUserInfoRequest CreateGetUserInfoRequest()
        {
            return new RenrenGetUserInfoRequest();
        }
    }
}
