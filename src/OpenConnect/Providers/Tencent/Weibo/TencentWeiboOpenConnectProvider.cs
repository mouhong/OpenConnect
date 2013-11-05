using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent.Weibo
{
    public class TencentWeiboOpenConnectProvider : IOpenConnectProvider
    {
        private IHttpClient _httpClient;

        public TencentWeiboOpenConnectProvider()
            : this(HttpClient.Instance)
        {
        }

        public TencentWeiboOpenConnectProvider(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new AuthorizationUriBuilder("https://open.t.qq.com/cgi-bin/oauth2/authorize");
        }

        public IAuthorizationCallbackParser GetAuthorizationCallbackParser()
        {
            return new AuthorizationCallbackParser();
        }

        public IAccessTokenRequest CreateAccessTokenRequest()
        {
            return new TencentAccessTokenRequest("https://open.t.qq.com/cgi-bin/oauth2/access_token", _httpClient);
        }

        public IUserInfoRequest CreateUserInfoRequest()
        {
            return new TencentWeiboUserInfoRequest(_httpClient);
        }
    }
}
