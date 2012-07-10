using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;
using System.Collections.Specialized;

namespace OpenConnect
{
    public interface IOpenConnectClient
    {
        AppInfo AppInfo { get; }

        string GetAuthorizationUrl(AuthorizationUrlParameters parameters);

        AccessTokenResponse GetAccessToken(AccessTokenRequestParameters parameters);

        IUserInfo GetUserInfo(UserInfoRequestParameters parameters);
    }

    public class AuthorizationUrlParameters
    {
        public ResponseType ResponseType { get; set; }

        public string RedirectUri { get; set; }

        public string Scope { get; set; }

        public string Display { get; set; }

        public NameValueCollection OtherParameters { get; set; }

        public AuthorizationUrlParameters(ResponseType responseType, string redirectUri)
        {
            ResponseType = responseType;
            RedirectUri = redirectUri;
            OtherParameters = new NameValueCollection();
        }

        public AuthorizationUrlParameters WithOtherParameter(string name, string value)
        {
            OtherParameters[name] = value;
            return this;
        }
    }

    public class AccessTokenRequestParameters
    {
        public string AuthorizationCode { get; set; }

        public string RedirectUri { get; set; }

        public string State { get; set; }

        public NameValueCollection OtherParameters { get; set; }

        public AccessTokenRequestParameters(string authorizationCode, string reidrectUri)
        {
            AuthorizationCode = authorizationCode;
            RedirectUri = reidrectUri;
            OtherParameters = new NameValueCollection();
        }

        public AccessTokenRequestParameters WithOtherParameter(string name, string value)
        {
            OtherParameters[name] = value;
            return this;
        }
    }

    public class UserInfoRequestParameters
    {
        public string AccessToken { get; set; }

        public NameValueCollection OtherParameters { get; set; }

        public UserInfoRequestParameters(string accessToken)
        {
            AccessToken = accessToken;
            OtherParameters = new NameValueCollection();
        }

        public UserInfoRequestParameters WithOtherParameter(string name, string value)
        {
            OtherParameters[name] = value;
            return this;
        }
    }
}
