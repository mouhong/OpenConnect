using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Taobao
{
    public class TaobaoOpenConnectProvider : OpenConnectProviderBase
    {
        public bool UseSandbox { get; set; }

        protected override string ApiBasePath
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
            : this(OpenConnect.Utils.HttpClient.Instance)
        {
        }

        public TaobaoOpenConnectProvider(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        protected override IAccessTokenRequest CreateAccessTokenRequest(AccessTokenRequestParameters parameters)
        {
            return new TaobaoAccessTokenRequest(ApiBasePath, HttpClient);
        }

        protected override IUserInfoRequest CreateUserInfoRequest(UserInfoRequestParameters parameters)
        {
            return new TaobaoUserInfoRequest(UseSandbox, HttpClient);
        }
    }
}
