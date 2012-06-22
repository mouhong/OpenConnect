using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using OpenConnect.Utils;

namespace OpenConnect.Providers.Renren
{
    public class RenrenGetUserInfoRequest : IGetUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public RenrenGetUserInfoRequest()
            : this(OpenConnect.Providers.HttpClient.Instance)
        {
        }

        public RenrenGetUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public IUserInfo GetResponse(AppInfo appInfo, string accessToken, string userId)
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

            return ParseRawResponse(json);
        }

        protected virtual IUserInfo ParseRawResponse(string jsonResponse)
        {
            var result = (List<RenrenUserInfo>)JsonSerializer.Deserialize(jsonResponse, typeof(List<RenrenUserInfo>));
            return result.FirstOrDefault();
        }
    }
}
