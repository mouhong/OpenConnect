using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;

namespace OpenConnect
{
    public interface IOpenConnectClient
    {
        AppInfo AppInfo { get; }

        string BuildLoginUrl(ResponseType responseType, string redirectUri, string scope, string display);

        AccessTokenResponse GetAccessToken(string authCode, string redirectUri, string state);

        IUserInfo GetUserInfo(string accessToken, string userId);
    }
}
