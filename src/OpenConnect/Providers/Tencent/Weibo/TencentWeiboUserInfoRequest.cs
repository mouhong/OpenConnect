using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Tencent.Weibo
{
    public class TencentWeiboUserInfoRequest : IUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public TencentWeiboUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            var url = UrlBuilder.Create("https://open.t.qq.com/api/user/info")
                                .WithParam("oauth_consumer_key", parameters.AppInfo.AppId)
                                .WithParam("access_token", parameters.AccessTokenResult.AccessToken)
                                .WithParam("scope", parameters.AppInfo.DefaultScope)
                                .WithParam("oauth_version", "2.a")
                                .WithParam("openid", parameters.AccessTokenResult.UserId)
                                .Build();

            var json = HttpClient.Get(url, null, Encoding.UTF8);

            var result = (UserInfoApiResult)JsonSerializer.Deserialize(json, typeof(UserInfoApiResult));

            if (result.ret != 0)
                throw new ApiException(result.msg, result.errcode.ToString());

            return result.data;
        }

        [DataContract]
        class UserInfoApiResult
        {
            [DataMember]
            public int ret = 0;

            [DataMember]
            public string msg = null;

            [DataMember]
            public int errcode = 0;

            [DataMember]
            public TencentWeiboUserInfo data = null;
        }
    }
}
