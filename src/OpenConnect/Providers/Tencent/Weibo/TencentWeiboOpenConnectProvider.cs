using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent.Weibo
{
    public class TencentWeiboOpenConnectProvider : OpenConnectProviderBase
    {
        protected override string ApiBasePath
        {
            get
            {
                return "https://open.t.qq.com/cgi-bin/oauth2/";
            }
        }

        public TencentWeiboOpenConnectProvider()
            : this(OpenConnect.Utils.HttpClient.Instance)
        {
        }

        public TencentWeiboOpenConnectProvider(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        protected override IAccessTokenRequest CreateAccessTokenRequest(AccessTokenRequestParameters parameters)
        {
            return new TencentAccessTokenRequest(UrlUtil.Combine(ApiBasePath, "access_token"), HttpClient);
        }

        protected override IUserInfoRequest CreateUserInfoRequest(UserInfoRequestParameters parameters)
        {
            return new TencentWeiboUserInfoRequest(HttpClient);
        }
    }
}
