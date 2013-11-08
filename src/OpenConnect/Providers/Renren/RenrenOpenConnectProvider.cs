using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Renren
{
    public class RenrenOpenConnectProvider : OpenConnectProviderBase
    {
        protected override string ApiBasePath
        {
            get
            {
                return "https://graph.renren.com/oauth/";
            }
        }

        public RenrenOpenConnectProvider()
            : this(OpenConnect.Utils.HttpClient.Instance)
        {
        }

        public RenrenOpenConnectProvider(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        protected override IUserInfoRequest CreateUserInfoRequest(UserInfoRequestParameters parameters)
        {
            return new RenrenUserInfoRequest(HttpClient);
        }
    }
}
