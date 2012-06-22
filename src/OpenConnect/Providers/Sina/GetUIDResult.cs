using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Weibo
{
    [DataContract]
    class GetUIDResult
    {
        [DataMember]
        public string uid = null;
    }
}
