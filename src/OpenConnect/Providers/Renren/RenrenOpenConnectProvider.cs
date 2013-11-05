using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Renren
{
    public class RenrenOpenConnectProvider : IOpenConnectProvider
    {
        private IHttpClient _httpClient;

        public RenrenOpenConnectProvider()
            : this(HttpClient.Instance)
        {
        }

        public RenrenOpenConnectProvider(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new AuthorizationUriBuilder("https://graph.renren.com/oauth/authorize");
        }

        public IAuthorizationCallbackParser GetAuthorizationCallbackParser()
        {
            return new AuthorizationCallbackParser();
        }

        public IAccessTokenRequest CreateAccessTokenRequest()
        {
            return new AccessTokenRequest("https://graph.renren.com/oauth/token", _httpClient);
        }

        public IUserInfoRequest CreateUserInfoRequest()
        {
            return new RenrenUserInfoRequest(_httpClient);
        }
    }
}
