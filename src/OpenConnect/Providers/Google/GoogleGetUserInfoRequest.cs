using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Utils;

namespace OpenConnect.Providers.Google
{
    public class GoogleGetUserInfoRequest : IGetUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public GoogleGetUserInfoRequest()
            : this(OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public GoogleGetUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public UserInfo GetResponse(AppInfo appInfo, string accessToken, string userOpenId)
        {
            var url = UrlBuilder.Create("https://www.googleapis.com/oauth2/v1/userinfo")
                                .WithParam("alt", "json")
                                .WithParam("access_token", accessToken)
                                .Build();

            var json = HttpClient.Get(url, null, Encoding.UTF8);
            var result = (GetUserInfoResult)JsonSerializer.Deserialize(json, typeof(GetUserInfoResult));

            return new UserInfo
            {
                Id = result.id,
                NickName = result.name,
                HeadImageUrl = result.picture,
                Gender = result.gender == "male" ? Gender.Male : Gender.Female
            };
        }
    }
}
