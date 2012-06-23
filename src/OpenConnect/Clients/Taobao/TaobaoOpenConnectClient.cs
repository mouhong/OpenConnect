using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Utils;
using OpenConnect.Clients.Utils;

namespace OpenConnect.Clients.Taobao
{
    public class TaobaoOpenConnectClient : IOpenConnectClient
    {
        private IHttpClient _httpClient;

        public AppInfo AppInfo { get; private set; }

        public bool UseSandbox { get; set; }

        public string BaseApiUri
        {
            get
            {
                if (UseSandbox)
                {
                    return "https://oauth.tbsandbox.com/";
                }

                return "https://oauth.taobao.com/";
            }
        }

        public string UserFieldsToGet { get; set; }

        public TaobaoOpenConnectClient(AppInfo appInfo)
            : this(appInfo, HttpClient.Instance)
        {
        }

        public TaobaoOpenConnectClient(AppInfo appInfo, IHttpClient httpClient)
        {
            AppInfo = appInfo;
            _httpClient = httpClient;
        }

        public string BuildLoginUrl(string display, ResponseType responseType)
        {
            return new LoginUrlBuilder(BaseApiUri + "authorize")
                        .Build(AppInfo, display, responseType);
        }

        public AccessTokenResponse GetAccessToken(string authCode, string state)
        {
            var now = DateTime.Now;

            var request = new GetAccessTokenRequest(BaseApiUri + "token", _httpClient)
            {
                Method = HttpMethod.Post
            };
            var response = request.GetResponse(AppInfo, authCode, state);

            return DefaultGetAccessTokenResponseParser.Parse(response, now);
        }

        public IUserInfo GetUserInfo(string accessToken, string userId)
        {
            var request = new TaobaoGetUserInfoRequest(UseSandbox, _httpClient);

            if (!String.IsNullOrEmpty(UserFieldsToGet))
            {
                request.FieldsToGet = UserFieldsToGet;
            }

            return request.GetResponse(AppInfo, accessToken);
        }
    }
}
