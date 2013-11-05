using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Live
{
    public class LiveOpenConnectProvider : IOpenConnectProvider
    {
        private IHttpClient _httpClient;

        public LiveOpenConnectProvider()
            : this(HttpClient.Instance)
        {
        }

        public LiveOpenConnectProvider(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new AuthorizationUriBuilder("https://oauth.live.com/authorize");
        }

        public IAuthorizationCallbackParser GetAuthorizationCallbackParser()
        {
            return new AuthorizationCallbackParser();
        }

        public IAccessTokenRequest CreateAccessTokenRequest()
        {
            return new AccessTokenRequest("https://oauth.live.com/token", _httpClient);
        }

        public IUserInfoRequest CreateUserInfoRequest()
        {
            return new LiveUserInfoRequest(_httpClient);
        }
    }
}
