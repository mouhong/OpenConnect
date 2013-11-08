using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public class UserInfoRequestParameters
    {
        public AppInfo AppInfo { get; set; }

        public AuthorizationResult AuthorizationResult { get; set; }

        public AccessTokenResult AccessTokenResult { get; set; }

        public UserInfoRequestParameters(AppInfo appInfo, AuthorizationResult authorizationResult, AccessTokenResult accessTokenResult)
        {
            Require.NotNull(appInfo, "appInfo");
            Require.NotNull(authorizationResult, "authorizationResult");
            Require.NotNull(accessTokenResult, "accessTokenResult");

            AppInfo = appInfo;
            AuthorizationResult = authorizationResult;
            AccessTokenResult = accessTokenResult;
        }
    }
}
