using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Taobao
{
    [DataContract]
    class GetUserInfoApiResponse
    {
        [DataMember]
        public UserGetResponse user_get_response = null;

        [DataMember]
        public ErrorResponse error_response = null;
    }
}
