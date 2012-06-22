using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Live
{
    public class LiveOpenConnectProvider : IOpenConnectProvider
    {
        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new OAuthAuthorizationUrlBuilder("https://oauth.live.com/authorize");
        }

        public IGetAccessTokenRequest GetAccessTokenRetriever()
        {
            return new OAuthGetAccessTokenRequest("https://oauth.live.com/token")
            {
                Method = HttpMethod.Get
            };
        }

        public IGetUserInfoRequest GetUserInfoRetriever()
        {
            return new LiveGetUserInfoRequest();
        }
    }
}
