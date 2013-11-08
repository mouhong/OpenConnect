using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OpenConnect
{
    public interface IOpenConnectProvider
    {
        string GetAuthorizationUrl(AuthorizationParameters parameters);

        AuthorizationResult ParseAuthorizationCallback(HttpRequestBase callbackRequest);

        AccessTokenResult GetAccessToken(AccessTokenRequestParameters parameters);

        IUserInfo GetUserInfo(UserInfoRequestParameters parameters);
    }
}
