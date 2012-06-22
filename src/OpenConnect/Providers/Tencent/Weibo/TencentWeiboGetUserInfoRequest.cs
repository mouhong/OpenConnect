using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;

namespace OpenConnect.Providers.Tencent.Weibo
{
    public class TencentWeiboGetUserInfoRequest : IGetUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public TencentWeiboGetUserInfoRequest()
            : this(OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public TencentWeiboGetUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public UserInfo GetResponse(AppInfo appInfo, string accessToken, string userOpenId)
        {
            Require.NotNull(appInfo, "appInfo");
            Require.NotNullOrEmpty(accessToken, "accessToken");

            var url = UrlBuilder.Create("https://open.t.qq.com/api/user/info")
                                .WithParam("oauth_consumer_key", appInfo.AppId)
                                .WithParam("access_token", accessToken)
                                .WithParam("scope", appInfo.Scope)
                                .WithParam("oauth_version", "2.a")
                                .WithParam("openid", userOpenId)
                                .Build();

            var json = HttpClient.Get(url, null, Encoding.UTF8);

            var result = (GetUserInfoResult)JsonSerializer.Deserialize(json, typeof(GetUserInfoResult));

            if (result.ret != 0)
                throw new ApiException(result.msg);

            if (result.data == null)
            {
                return null;
            }

            return new UserInfo
            {
                Id = result.data.openid,
                Email = result.data.email,
                Gender = result.data.sex == 1 ? Gender.Male : (result.data.sex == 2 ? Gender.Female : Gender.Unknown),
                NickName = result.data.nick,
                HeadImageUrl = String.IsNullOrEmpty(result.data.head) ? null : result.data.head + "/100"
            };
        }
    }
}
