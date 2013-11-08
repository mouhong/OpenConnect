using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent.QQ
{
    public class QQOpenConnectProvider : OpenConnectProviderBase
    {
        protected override string ApiBasePath
        {
            get
            {
                return "https://graph.qq.com/oauth2.0/";
            }
        }

        public QQOpenConnectProvider()
            : this(OpenConnect.Utils.HttpClient.Instance)
        {
        }

        public QQOpenConnectProvider(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        protected override IAccessTokenRequest CreateAccessTokenRequest(AccessTokenRequestParameters parameters)
        {
            return new TencentAccessTokenRequest(UrlUtil.Combine(ApiBasePath, "token"), HttpClient);
        }

        protected override IUserInfoRequest CreateUserInfoRequest(UserInfoRequestParameters parameters)
        {
            return new QQUserInfoRequest(HttpClient);
        }
    }
}
