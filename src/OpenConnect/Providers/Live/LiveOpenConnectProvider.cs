using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Live
{
    public class LiveOpenConnectProvider : IOpenConnectProvider
    {
        public LiveOpenConnectProvider()
        {
        }

        public virtual ILoginUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new StandardLoginUrlBuilder("https://oauth.live.com/authorize");
        }

        public virtual IGetAccessTokenRequest CreateGetAccessTokenRequest()
        {
            return new StandardGetAccessTokenRequest("https://oauth.live.com/token")
            {
                Method = HttpMethod.Get
            };
        }

        public virtual IGetUserInfoRequest CreateGetUserInfoRequest()
        {
            return new LiveGetUserInfoRequest();
        }
    }
}
