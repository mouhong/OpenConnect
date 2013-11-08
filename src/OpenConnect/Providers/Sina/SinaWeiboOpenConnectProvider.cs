using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Sina
{
    public class SinaWeiboOpenConnectProvider : OpenConnectProviderBase
    {
        protected override string ApiBasePath
        {
            get
            {
                return "https://api.weibo.com/oauth2/";
            }
        }

        public SinaWeiboOpenConnectProvider()
            : this(OpenConnect.Utils.HttpClient.Instance)
        {
        }

        public SinaWeiboOpenConnectProvider(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        protected override IAccessTokenRequest CreateAccessTokenRequest(AccessTokenRequestParameters parameters)
        {
            return new AccessTokenRequest(UrlUtil.Combine(ApiBasePath, "access_token"), HttpClient)
            {
                Method = HttpMethod.Post
            };
        }

        protected override IUserInfoRequest CreateUserInfoRequest(UserInfoRequestParameters parameters)
        {
            return new SinaWeiboUserInfoRequest(HttpClient);
        }
    }
}
