using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Sina
{
    public class SinaWeiboOpenConnectProvider : IOpenConnectProvider
    {
        private IHttpClient _httpClient;

        public bool UseSandbox { get; set; }

        public SinaWeiboOpenConnectProvider()
            : this(HttpClient.Instance)
        {
        }

        public SinaWeiboOpenConnectProvider(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new AuthorizationUriBuilder("https://api.weibo.com/oauth2/authorize");
        }

        public IAuthorizationCallbackParser GetAuthorizationCallbackParser()
        {
            return new AuthorizationCallbackParser();
        }

        public IAccessTokenRequest CreateAccessTokenRequest()
        {
            return new AccessTokenRequest("https://api.weibo.com/oauth2/access_token", _httpClient)
            {
                Method = HttpMethod.Post
            };
        }

        public IUserInfoRequest CreateUserInfoRequest()
        {
            return new SinaWeiboUserInfoRequest(_httpClient);
        }
    }
}
