using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Utils;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Tencent.QQ
{
    public class QQUserInfoRequest : IUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public QQUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            var userInfo = GetUserInfoByUserIdentity(
                parameters.AppInfo, parameters.AccessTokenResult.AccessToken, GetUserIdentity(parameters.AccessTokenResult.AccessToken));

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

        private IUserInfo GetUserInfoByUserIdentity(AppInfo appInfo, string accessToken, string userIdentity)
        {
            var url = UrlBuilder.Create("https://graph.qq.com/user/get_user_info")
                                .WithParam("access_token", accessToken)
                                .WithParam("oauth_consumer_key", appInfo.AppId)
                                .WithParam("openid", userIdentity)
                                .Build();

            var json = HttpClient.Get(url, null, Encoding.UTF8);
            var result = (ApiResult)JsonSerializer.Deserialize(json, typeof(ApiResult));

            if (result.ret < 0)
                throw new ApiException(result.msg, result.ret.ToString());

            result.Id = userIdentity;

            return result;
        }

        [DataContract]
        class ApiResult : QQUserInfo
        {
            [DataMember]
            public int ret = 0;

            [DataMember]
            public string msg = null;
        }
    }
}
