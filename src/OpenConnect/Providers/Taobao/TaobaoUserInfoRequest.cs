using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using OpenConnect.Utils;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Taobao
{
    public class TaobaoUserInfoRequest : IUserInfoRequest
    {
        private string _fieldsToGet = "uid,nick,sex,buyer_credit,seller_credit,location,type,avatar,has_shop,is_golden_seller,vip_info";

        public IHttpClient HttpClient { get; private set; }

        public bool UseSandboxMode { get; set; }

        public string FieldsToGet
        {
            get
            {
                return _fieldsToGet;
            }
            set
            {
                _fieldsToGet = value;
            }
        }

        public TaobaoUserInfoRequest(bool useSandboxMode, IHttpClient httpClient)
        {
            HttpClient = httpClient;
            UseSandboxMode = useSandboxMode;
        }

        public IUserInfo GetUserInfo(UserInfoRequestParameters parameters)
        {
            var data = new NameValueCollection()
                                    .FluentAdd("format", "json")
                                    .FluentAdd("method", "taobao.user.get")
                                    .FluentAdd("sign_method", "md5")
                                    .FluentAdd("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                    .FluentAdd("v", "2.0")
                                    .FluentAdd("session", parameters.AccessTokenResult.AccessToken)
                                    .FluentAdd("app_key", parameters.AppInfo.AppId)
                                    .FluentAdd("fields", FieldsToGet);

            var sign = TaobaoApiUtil.Sign(data, parameters.AppInfo.AppSecret);

            data.Add("sign", sign);

            var json = HttpClient.Get(GetApiPath(), data, Encoding.UTF8);

            var result = (ApiResponse)JsonSerializer.Deserialize(json, typeof(ApiResponse));

            if (result.error_response != null && !String.IsNullOrEmpty(result.error_response.code))
            {
                throw CreateErrorResponseException(result.error_response);
            }

            if (result.user_get_response.user == null)
            {
                return null;
            }

            return result.user_get_response.user;
        }

        private ApiException CreateErrorResponseException(ErrorResponse response)
        {
            Exception innerException = null;

            if (!String.IsNullOrEmpty(response.sub_code))
            {
                innerException = new ApiException(response.sub_msg, response.sub_code);
            }

            if (innerException == null)
            {
                return new ApiException(response.msg, response.code);
            }

            return new ApiException(response.msg, response.code, innerException);
        }

        private string GetApiPath()
        {
            if (UseSandboxMode)
            {
                return "http://gw.api.tbsandbox.com/router/rest";
            }

            return "http://gw.api.taobao.com/router/rest";
        }

        [DataContract]
        class ApiResponse
        {
            [DataMember]
            public UserGetResponse user_get_response = null;

            [DataMember]
            public ErrorResponse error_response = null;
        }
    }
}
