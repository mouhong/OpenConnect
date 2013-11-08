using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OpenConnect.Providers.Google
{
    public class GoogleOpenConnectProvider : OpenConnectProviderBase
    {
        protected override string ApiBasePath
        {
            get
            {
                return "https://accounts.google.com/o/oauth2/";
            }
        }

        public GoogleOpenConnectProvider()
            : this(OpenConnect.Utils.HttpClient.Instance)
        {
        }

        public GoogleOpenConnectProvider(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        protected override AuthorizationUrlBuilder GetAuthorizationUrlBuilder(AuthorizationParameters parameters)
        {
            var builder = new AuthorizationUrlBuilder("https://accounts.google.com/o/oauth2/auth");
            builder.DisplayParamName = "approval_prompt";
            return builder;
        }

        protected override IAccessTokenRequest CreateAccessTokenRequest(AccessTokenRequestParameters parameters)
        {
            return new GoogleAccessTokenRequest(HttpClient);
        }

        protected override IUserInfoRequest CreateUserInfoRequest(UserInfoRequestParameters parameters)
        {
            return new GoogleUserInfoRequest(HttpClient);
        }
    }
}
