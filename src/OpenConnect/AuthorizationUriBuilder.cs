using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    public class AuthorizationUriBuilder : IAuthorizationUrlBuilder
    {
        public string ApiPath { get; set; }

        public string ResponseTypeParamName { get; set; }

        public string ClientIdParamName { get; set; }

        public string RedirectUriParamName { get; set; }

        public string ScopeParamName { get; set; }

        public string DisplayParamName { get; set; }

        public AuthorizationUriBuilder(string apiPath)
        {
            ApiPath = apiPath;
            ResponseTypeParamName = "response_type";
            ClientIdParamName = "client_id";
            RedirectUriParamName = "redirect_uri";
            ScopeParamName = "scope";
            DisplayParamName = "display";
        }

        public string GetAuthorizationUri(AuthorizationParameters parameters, AppInfo appInfo)
        {
            var builder = UrlBuilder.Create(ApiPath);
            SetupUriParameters(builder, parameters, appInfo);
            return builder.Build();
        }

        protected virtual void SetupUriParameters(UrlBuilder builder, AuthorizationParameters parameters, AppInfo appInfo)
        {
            builder.WithParam(ResponseTypeParamName, parameters.ResponseType == ResponseType.Code ? "code" : "token")
                   .WithParam(ClientIdParamName, appInfo.AppId)
                   .WithParam(RedirectUriParamName, parameters.RedirectUri)
                   .WithParam(ScopeParamName, String.IsNullOrEmpty(parameters.Scope) ? appInfo.DefaultScope : parameters.Scope)
                   .WithParam(DisplayParamName, parameters.Display);
        }
    }
}
