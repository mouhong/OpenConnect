using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using OpenConnect.Utils;

namespace OpenConnect.Clients
{
    static class DefaultGetAccessTokenResponseParser
    {
        public static AccessTokenResponse Parse(string response, DateTime startRequestTime)
        {
            var result = (GetAccessTokenResult)JsonSerializer.Deserialize(response, typeof(GetAccessTokenResult));
            var token = new AccessTokenResponse(result.access_token, startRequestTime.AddSeconds(result.expires_in), result.refresh_token, null)
            {
                UserId = result.uid,
                UserName = result.name
            };

            if (!String.IsNullOrEmpty(result.taobao_user_id))
            {
                token.UserId = result.taobao_user_id;
            }
            if (!String.IsNullOrEmpty(result.taobao_user_nick))
            {
                token.UserName = result.taobao_user_nick;
            }

            return token;
        }

        [DataContract]
        private class GetAccessTokenResult
        {
            [DataMember]
            public string access_token = null;

            [DataMember]
            public int expires_in = 0;

            [DataMember]
            public string refresh_token = null;

            [DataMember]
            public string uid = null;

            [DataMember]
            public string name = null;

            [DataMember]
            public string taobao_user_id = null;

            [DataMember]
            public string taobao_user_nick = null;
        }
    }
}
