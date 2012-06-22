using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public interface IUserInfoRetriever
    {
        UserInfo Retrieve(AppInfo appInfo, string accessToken, string userOpenId);
    }
}
