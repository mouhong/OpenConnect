using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Google
{
    public class GoogleOpenConnectProvider : IOpenConnectProvider
    {
        public GoogleOpenConnectProvider()
        {
        }

        public virtual ILoginUrlBuilder GetLoginUrlBuilder()
        {
            return new GoogleAuthorizationUrlBuilder();
        }

        public virtual IGetAccessTokenRequest CreateGetAccessTokenRequest()
        {
            return new GoogleGetAccessTokenRequest
            {
                Method = HttpMethod.Post
            };
        }

        public virtual IGetUserInfoRequest CreateGetUserInfoRequest()
        {
            return new GoogleGetUserInfoRequest();
        }
    }
}
