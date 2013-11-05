using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Taobao
{
    public class TaobaoOpenConnectProvider : IOpenConnectProvider
    {
        private IHttpClient _httpClient;

        public bool UseSandbox { get; set; }

        public string BaseApiUri
        {
            get
            {
                if (UseSandbox)
                {
                    return "https://oauth.tbsandbox.com/";
                }

                return "https://oauth.taobao.com/";
            }
        }

        public TaobaoOpenConnectProvider()
            : this(HttpClient.Instance)
        {
        }

        public TaobaoOpenConnectProvider(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IAuthorizationUrlBuilder GetAuthorizationUrlBuilder()
        {
            return new AuthorizationUriBuilder(BaseApiUri + "authorize");
        }

        public IAuthorizationCallbackParser GetAuthorizationCallbackParser()
        {
            return new AuthorizationCallbackParser();
        }

        public IAccessTokenRequest CreateAccessTokenRequest()
        {
            return new TaobaoAccessTokenRequest(BaseApiUri, _httpClient);
        }

        public IUserInfoRequest CreateUserInfoRequest()
        {
            return new TaobaoUserInfoRequest(UseSandbox, _httpClient);
        }
    }
}
