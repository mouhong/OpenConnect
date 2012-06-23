using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization;

using OpenConnect.Utils;

namespace OpenConnect.Providers.Sina
{
    public class SinaWeiboGetUserInfoRequest : IGetUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public SinaWeiboGetUserInfoRequest()
            : this(OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public SinaWeiboGetUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public IUserInfo GetResponse(AppInfo appInfo, string accessToken, string userId)
        {
            Require.NotNull(appInfo, "appInfo");
            Require.NotNullOrEmpty(accessToken, "accessToken");

            if (String.IsNullOrEmpty(userId))
            {
                userId = GetUID(accessToken);
            }

            var userInfo = GetUserInfoByUserIdentity(accessToken, userId);

            return userInfo;
        }

        private string GetUID(string accessToken)
        {
            var data = new NameValueCollection().FluentAdd("access_token", accessToken);

            var json = HttpClient.Get("https://api.weibo.com/2/account/get_uid.json", data, Encoding.UTF8);
            var result = (GetUIDResult)JsonSerializer.Deserialize(json, typeof(GetUIDResult));

            return result.uid;
        }

        private IUserInfo GetUserInfoByUserIdentity(string accessToken, string uid)
        {
            var data = new NameValueCollection().FluentAdd("access_token", accessToken)
                                                .FluentAdd("uid", uid);

            var json = HttpClient.Get("https://api.weibo.com/2/users/show.json", data, Encoding.UTF8);
            
            return (SinaWeiboUserInfo)JsonSerializer.Deserialize(json, typeof(SinaWeiboUserInfo));
        }

        [DataContract]
        class GetUIDResult
        {
            [DataMember]
            public string uid = null;
        }
    }
}
