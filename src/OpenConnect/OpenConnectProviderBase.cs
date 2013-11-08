using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public abstract class OpenConnectProviderBase : IOpenConnectProvider
    {
        protected IHttpClient HttpClient { get; set; }

        protected abstract string ApiBasePath { get; }

        protected OpenConnectProviderBase(IHttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public virtual string GetAuthorizationUrl(AuthorizationParameters parameters)
        {
            return GetAuthorizationUrlBuilder(parameters).GetAuthorizationUrl(parameters);
        }

        protected virtual AuthorizationUrlBuilder GetAuthorizationUrlBuilder(AuthorizationParameters parameters)
        {
            return new AuthorizationUrlBuilder(UrlUtil.Combine(ApiBasePath, "authorize"));
        }

        public virtual AuthorizationResult ParseAuthorizationCallback(System.Web.HttpRequestBase callbackRequest)
        {
            return GetAuthorizationCallbackParser().Parse(callbackRequest);
        }

        protected virtual IAuthorizationCallbackParser GetAuthorizationCallbackParser()
        {
            return new AuthorizationCallbackParser();
        }

        public virtual AccessTokenResult GetAccessToken(AccessTokenRequestParameters parameters)
        {
            return CreateAccessTokenRequest(parameters).GetAccessToken(parameters);
        }

        protected virtual IAccessTokenRequest CreateAccessTokenRequest(AccessTokenRequestParameters parameters)
        {
            return new AccessTokenRequest(UrlUtil.Combine(ApiBasePath, "token"), HttpClient);
        }

        public virtual IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            return CreateUserInfoRequest(parameters).GetUserInfo(parameters);
        }

        protected abstract IUserInfoRequest CreateUserInfoRequest(UserInfoRequestParameters parameters);
    }
}
