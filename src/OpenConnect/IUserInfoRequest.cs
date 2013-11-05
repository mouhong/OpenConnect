using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public interface IUserInfoRequest
    {
        IUserInfo GetUserInfo(UserInfoRequestParameters parameters);
    }
}
