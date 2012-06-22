using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Tencent.QQ
{
    [DataContract]
    class GetUserInfoResult : QQUserInfo
    {
        [DataMember]
        public int ret = 0;

        [DataMember]
        public string msg = null;
    }
}
