using OpenConnect.Utils;
using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Text;

namespace OpenConnect
{
    public class AccessTokenRequest : IAccessTokenRequest
    {
        protected IHttpClient HttpClient { get; private set; }

        public string ApiPath { get; set; }

        public HttpMethod Method { get; set; }

        public AccessTokenRequest(string apiPath, IHttpClient httpClient)
        {
            ApiPath = apiPath;
            HttpClient = httpClient;
        }

        public virtual AccessTokenResult GetAccessToken(AccessTokenRequestParameters parameters)
        {
            var data = new NameValueCollection().FluentAdd("client_id", parameters.AppInfo.AppId)
                                                .FluentAdd("client_secret", parameters.AppInfo.AppSecret)
                                                .FluentAdd("redirect_uri", parameters.RedirectUri)
                                                .FluentAdd("code", parameters.AuthorizationResult.Code)
                                                .FluentAdd("grant_type", "authorization_code")
                                                .AddIfValueIsNotNullOrEmpty("state", parameters.State);

            string responseText = null;

            if (Method == HttpMethod.Get)
            {
                responseText = HttpClient.Get(ApiPath, data, Encoding.UTF8);
            }
            else
            {
                responseText = HttpClient.Post(ApiPath, data, Encoding.UTF8);
            }

            return ParseAccessTokenResponse(responseText, parameters);
        }

        protected virtual AccessTokenResult ParseAccessTokenResponse(string responseText, AccessTokenRequestParameters request)
        {
            var result = (AccessTokenApiResult)JsonSerializer.Deserialize(responseText, typeof(AccessTokenApiResult));
            var token = new AccessTokenResult
            {
                AccessToken = result.access_token,
                AccessTokenExpireTime = DateTime.Now.AddSeconds(result.expires_in),
                RefreshToken = result.refresh_token,
                UserId = request.AuthorizationResult.UserId
            };

            return token;
        }

        [DataContract]
        class AccessTokenApiResult
        {
            [DataMember]
            public string access_token = null;

            [DataMember]
            public int expires_in = 0;

            [DataMember]
            public string refresh_token = null;
        }
    }
}
