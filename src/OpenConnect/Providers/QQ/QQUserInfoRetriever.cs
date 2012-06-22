using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Utils;

namespace OpenConnect.Providers.QQ
{
    public class QQUserInfoRetriever : IUserInfoRetriever
    {
        public IHttpClient HttpClient { get; private set; }

        public QQUserInfoRetriever()
            : this(OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public QQUserInfoRetriever(IHttpClient httpClient)
        {
            Check.RequireNotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public UserInfo Retrieve(AppInfo appInfo, string accessToken)
        {
            Check.RequireNotNull(appInfo, "appInfo");
            Check.RequireNotNullOrEmpty(accessToken, "accessToken");

            var uid = GetUserIdentity(accessToken);
            var userInfo = GetUserInfoByUserIdentity(appInfo, accessToken, uid);

            return userInfo;
        }

        private string GetUserIdentity(string accessToken)
        {
            var url = "https://graph.qq.com/oauth2.0/me?access_token=" + accessToken;

            var result = HttpClient.Get(url, null, Encoding.UTF8);

            var pattern = "\"openid\":\"";
            var index = result.IndexOf(pattern);

            if (index >= 0)
            {
                var end = result.IndexOf('"', index + pattern.Length);

                if (end >= 0)
                {
                    return result.Substring(index + pattern.Length, end - (index + pattern.Length));
                }
            }

            throw new ApiException("Unrecognized response: " + result + ".");
        }

        private UserInfo GetUserInfoByUserIdentity(AppInfo appInfo, string accessToken, string userIdentity)
        {
            var url = UrlBuilder.Create("https://graph.qq.com/user/get_user_info")
                                .WithParam("access_token", accessToken)
                                .WithParam("oauth_consumer_key", appInfo.AppId)
                                .WithParam("openid", userIdentity)
                                .Build();

            var json = HttpClient.Get(url, null, Encoding.UTF8);
            var result = (GetUserInfoResult)JsonSerializer.Deserialize(json, typeof(GetUserInfoResult));

            if (result.ret < 0)
                throw new ApiException(result.msg, result.ret.ToString());

            var user = result.ToUserInfo();
            user.Id = userIdentity;

            return user;
        }
    }
}
