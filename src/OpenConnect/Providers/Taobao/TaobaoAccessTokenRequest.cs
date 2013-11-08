using OpenConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenConnect.Providers.Taobao
{
    public class TaobaoAccessTokenRequest : AccessTokenRequest
    {
        public TaobaoAccessTokenRequest(string baseApi, IHttpClient httpClient)
            : base(UrlUtil.Combine(baseApi, "token"), httpClient)
        {
            Method = HttpMethod.Post;
        }
        
        protected override AccessTokenResult ParseAccessTokenResponse(string responseText, AccessTokenRequestParameters request)
        {
            var result = (ApiResponse)JsonSerializer.Deserialize(responseText, typeof(ApiResponse));

            return new TaobaoAccessTokenResponse
            {
                AccessToken = result.access_token,
                AccessTokenExpireTime = DateTime.Now.AddSeconds(result.expires_in),
                RefreshToken = result.refresh_token,
                UserId = result.taobao_user_id,
                UserNick = result.taobao_user_nick
            };
        }

        [DataContract]
        class ApiResponse
        {
            [DataMember]
            public string access_token = null;

            [DataMember]
            public int expires_in = 0;

            [DataMember]
            public string refresh_token = null;

            [DataMember]
            public string taobao_user_id = null;

            [DataMember]
            public string taobao_user_nick = null;
        }
    }
}
