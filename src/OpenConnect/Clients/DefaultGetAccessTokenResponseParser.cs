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

            return new AccessTokenResponse(result.access_token, startRequestTime.AddSeconds(result.expires_in), result.refresh_token, null);
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
        }
    }
}
