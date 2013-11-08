using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using OpenConnect.Utils;

namespace OpenConnect.Providers.Renren
{
    public class RenrenUserInfoRequest : IUserInfoRequest
    {
        public IHttpClient HttpClient { get; private set; }

        public RenrenUserInfoRequest(IHttpClient httpClient)
        {
            Require.NotNull(httpClient, "httpClient");

            HttpClient = httpClient;
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            var apiPath = "http://api.renren.com/restserver.do";

            var data = new NameValueCollection().FluentAdd("method", "users.getInfo")
                                                .FluentAdd("v", "1.0")
                                                .FluentAdd("access_token", parameters.AccessTokenResult.AccessToken)
                                                .FluentAdd("format", "json")
                                                .FluentAdd("fields", "uid,name,sex,headurl");

            var sig = RenrenApiUtil.Sign(data, parameters.AppInfo.AppSecret);

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
