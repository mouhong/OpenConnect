using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Taobao
{
    public class TaobaoOpenConnectProvider : IOpenConnectProvider
    {
        public bool UseSandboxMode { get; set; }

        public string UserInfoFieldsToGet { get; set; }

        protected virtual string BaseApiPath
        {
            get
            {
                if (UseSandboxMode)
                {
                    return "https://oauth.tbsandbox.com/";
                }

                return "https://oauth.taobao.com/";
            }
        }

        public TaobaoOpenConnectProvider()
        {
        }

        public virtual ILoginUrlBuilder GetLoginUrlBuilder()
        {
            return new StandardLoginUrlBuilder(BaseApiPath + "authorize");
        }

        public virtual IGetAccessTokenRequest CreateGetAccessTokenRequest()
        {
            return new StandardGetAccessTokenRequest(BaseApiPath + "token")
            {
                Method = HttpMethod.Post
            };
        }

        public virtual IGetUserInfoRequest CreateGetUserInfoRequest()
        {
            var request = new TaobaoGetUserInfoRequest(UseSandboxMode);

            if (!String.IsNullOrEmpty(UserInfoFieldsToGet))
            {
                request.FieldsToGet = UserInfoFieldsToGet;
            }

            return request;
        }
    }
}
