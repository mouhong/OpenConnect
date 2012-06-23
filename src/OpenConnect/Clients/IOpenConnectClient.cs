using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;

namespace OpenConnect.Clients
{
    public interface IOpenConnectClient
    {
        AppInfo AppInfo { get; }

        string BuildLoginUrl(string display, ResponseType responseType);

        AccessTokenResponse GetAccessToken(string authCode, string state);

        IUserInfo GetUserInfo(string accessToken, string userId);
    }
}
