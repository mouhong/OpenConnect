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

        public IAccessTokenRetriever GetAccessTokenRetriever()
        {
            return new GoogleAccessTokenRetriver
            {
                Method = HttpMethod.Post
            };
        }

        public IUserInfoRetriever GetUserInfoRetriever()
        {
            return new GoogleUserInfoRetriever();
        }
    }
}
