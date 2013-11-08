using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OpenConnect.Providers.Live
{
    public class LiveOpenConnectProvider : OpenConnectProviderBase
    {
        protected override string ApiBasePath
        {
            get
            {
                return "https://oauth.live.com/";
            }
        }

        public LiveOpenConnectProvider()
            : this(OpenConnect.Utils.HttpClient.Instance)
        {
        }

        public LiveOpenConnectProvider(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        protected override IUserInfoRequest CreateUserInfoRequest(UserInfoRequestParameters parameters)
        {
            return new LiveUserInfoRequest(HttpClient);
        }
    }
}
