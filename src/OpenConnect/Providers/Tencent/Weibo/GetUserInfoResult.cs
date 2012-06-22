using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Tencent.Weibo
{
    [DataContract]
    class GetUserInfoResult
    {
        [DataMember]
        public int ret = 0;

        [DataMember]
        public string msg = null;

        [DataMember]
        public int errcode = 0;

        [DataMember]
        public TencentWeiboUserInfo data = null;
    }
}
