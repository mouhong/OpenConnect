using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Google
{
    public class GoogleAuthorizationUrlBuilder : IAuthorizationUrlBuilder
    {
        public string Build(AppInfo appInfo, string display, ResponseType responseType)
        {
            Require.NotNull(appInfo, "appInfo");

            var builder = UrlBuilder.Create("https://accounts.google.com/o/oauth2/auth")
                                    .WithParam("response_type", responseType == ResponseType.Code ? "code" : "token")
                                    .WithParam("client_id", appInfo.AppId)
                                    .WithParam("redirect_uri", appInfo.RedirectUri)
                                    .WithParam("approval_prompt", display)
                                    .WithParam("scope", appInfo.Scope);

            return builder.Build();
        }
    }
}
