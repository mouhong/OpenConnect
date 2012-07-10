using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Google
{
    public class GoogleOpenConnectClient : IOpenConnectClient
    {
        private IHttpClient _httpClient;

        public AppInfo AppInfo { get; private set; }

        public GoogleOpenConnectClient(AppInfo appInfo)
            : this(appInfo, HttpClient.Instance)
        {
        }

        public GoogleOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            _httpClient = httpClient;
        }

        public string GetAuthorizationUrl(AuthorizationUrlParameters parameters)
        {
            var builder = new LoginUrlBuilder("https://accounts.google.com/o/oauth2/auth");
            builder.DisplayParamName = "approval_prompt";
            builder.OtherParameters = parameters.OtherParameters;

            return builder.Build(AppInfo, parameters.ResponseType, parameters.RedirectUri, parameters.Scope, parameters.Display);
        }

        public AccessTokenResponse GetAccessToken(AccessTokenRequestParameters parameters)
        {
            var now = DateTime.Now;

            // state must be null in google
            parameters.State = null;

            var request = new GetAccessTokenRequest("https://accounts.google.com/o/oauth2/token", _httpClient);
            var response = request.GetResponse(AppInfo, parameters);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            return new GoogleGetUserInfoRequest(_httpClient).GetResponse(AppInfo, parameters.AccessToken);
        }
    }
}
