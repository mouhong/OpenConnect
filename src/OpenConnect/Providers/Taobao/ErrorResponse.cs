using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Taobao
{
    [DataContract]
    class ErrorResponse
    {
        [DataMember]
        public string code = null;

        [DataMember]
        public string msg = null;

        [DataMember]
        public string sub_code = null;

        [DataMember]
        public string sub_msg = null;
    }
}
