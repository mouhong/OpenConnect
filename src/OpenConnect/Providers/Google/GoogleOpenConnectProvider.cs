using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Google
{
    public class GoogleOpenConnectProvider : IOpenConnectProvider
    {
        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new GoogleAuthorizationUrlBuilder();
        }

        public IGetAccessTokenRequest GetAccessTokenRetriever()
        {
            return new GoogleGetAccessTokenRequest
            {
                Method = HttpMethod.Post
            };
        }

        public IGetUserInfoRequest GetUserInfoRetriever()
        {
            return new GoogleGetUserInfoRequest();
        }
    }
}
