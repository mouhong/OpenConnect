using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Google
{
    public class GoogleOpenConnectProvider : IOpenConnectProvider
    {
        private IHttpClient _httpClient;

        public GoogleOpenConnectProvider()
            : this(HttpClient.Instance)
        {
        }

        public GoogleOpenConnectProvider(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            var builder = new AuthorizationUriBuilder("https://accounts.google.com/o/oauth2/auth");
            builder.DisplayParamName = "approval_prompt";
            return builder;
        }

        public IAuthorizationCallbackParser GetAuthorizationCallbackParser()
        {
            return new AuthorizationCallbackParser();
        }

        public IAccessTokenRequest CreateAccessTokenRequest()
        {
            return new GoogleAccessTokenRequest(_httpClient);
        }

        public IUserInfoRequest CreateUserInfoRequest()
        {
            return new GoogleUserInfoRequest(_httpClient);
        }
    }
}
