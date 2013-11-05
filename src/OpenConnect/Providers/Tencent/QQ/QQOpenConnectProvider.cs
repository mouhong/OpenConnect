using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent.QQ
{
    public class QQOpenConnectProvider : IOpenConnectProvider
    {
        private IHttpClient _httpClient;

        public QQOpenConnectProvider()
            : this(HttpClient.Instance)
        {
        }

        public QQOpenConnectProvider(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new AuthorizationUriBuilder("https://graph.qq.com/oauth2.0/authorize");
        }

        public IAuthorizationCallbackParser GetAuthorizationCallbackParser()
        {
            return new AuthorizationCallbackParser();
        }

        public IAccessTokenRequest CreateAccessTokenRequest()
        {
            return new TencentAccessTokenRequest("https://graph.qq.com/oauth2.0/token", _httpClient);
        }

        public IUserInfoRequest CreateUserInfoRequest()
        {
            return new QQUserInfoRequest(_httpClient);
        }
    }
}
