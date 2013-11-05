using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public class UserInfoRequestParameters
    {
        public AppInfo AppInfo { get; set; }

        public AuthorizationResult AuthorizationResponse { get; set; }

        public AccessTokenResponse AccessTokenResponse { get; set; }

        public UserInfoRequestParameters(AppInfo appInfo, AuthorizationResult authorizationResponse, AccessTokenResponse accessTokenResponse)
        {
            AppInfo = appInfo;
            AuthorizationResponse = authorizationResponse;
            AccessTokenResponse = accessTokenResponse;
        }
    }
}
