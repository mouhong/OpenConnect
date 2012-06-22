using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using OpenConnect.Utils;

namespace OpenConnect.Providers.Renren
{
    public class RenrenUserInfoRetriever : IUserInfoRetriever
    {
        public IHttpClient HttpClient { get; private set; }

        public RenrenUserInfoRetriever()
            : this(OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public RenrenUserInfoRetriever(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public UserInfo Retrieve(AppInfo appInfo, string accessToken, string userOpenId)
        {
            var apiPath = "http://api.renren.com/restserver.do";

            var data = new NameValueCollection().FluentAdd("method", "users.getInfo")
                                                .FluentAdd("v", "1.0")
                                                .FluentAdd("access_token", accessToken)
                                                .FluentAdd("format", "json")
                                                .FluentAdd("fields", "uid,name,sex,headurl");

            var sig = RenrenApiUtil.Sign(data, appInfo.AppSecret);

            data.Add("sig", sig);

            var json = HttpClient.Post(apiPath, data, Encoding.UTF8);
            var result = (List<GetUserInfoResult>)JsonSerializer.Deserialize(json, typeof(List<GetUserInfoResult>));

            if (result.Count > 0)
            {
                var user = result[0];

                return new UserInfo
                {
                    Id = user.uid,
                    NickName = user.name,
                    HeadImageUrl = user.headurl,
                    Gender = user.sex == "1" ? Gender.Male : Gender.Female
                };
            }

            return null;
        }

        [DataContract]
        class GetUserInfoResult
        {
            [DataMember]
            public string uid;

            [DataMember]
            public string name;

            [DataMember]
            public string sex;

            [DataMember]
            public string headurl;
        }
    }
}
