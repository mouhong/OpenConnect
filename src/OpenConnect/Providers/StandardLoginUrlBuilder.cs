using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public class StandardLoginUrlBuilder : ILoginUrlBuilder
    {
        public string ApiPath { get; private set; }

        public StandardLoginUrlBuilder(string apiPath)
        {
            Require.NotNullOrEmpty(apiPath, "apiPath");

            ApiPath = apiPath;
        }

        public string Build(AppInfo appInfo, string display, ResponseType responseType)
        {
            Require.NotNull(appInfo, "appInfo");

            var builder = UrlBuilder.Create(ApiPath)
                                    .WithParam("response_type", responseType == ResponseType.Code ? "code" : "token")
                                    .WithParam("client_id", appInfo.AppId)
                                    .WithParam("redirect_uri", appInfo.RedirectUri)
                                    .WithParam("scope", appInfo.Scope)
                                    .WithParam("display", display);

            return builder.Build();
        }
    }
}
