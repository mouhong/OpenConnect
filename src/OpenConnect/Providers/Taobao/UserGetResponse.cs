using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Taobao
{
    [DataContract]
    class UserGetResponse
    {
        [DataMember]
        public TaobaoUserInfo user = null;
    }
}
