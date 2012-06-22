using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public interface IGetUserInfoRequest
    {
        UserInfo GetResponse(AppInfo appInfo, string accessToken, string userOpenId);
    }
}
