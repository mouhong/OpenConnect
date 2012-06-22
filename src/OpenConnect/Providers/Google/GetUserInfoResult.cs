using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Google
{
    [DataContract]
    class GetUserInfoResult
    {
        [DataMember]
        public string id = null;

        [DataMember]
        public string name = null;

        [DataMember]
        public string given_name = null;

        [DataMember]
        public string family_name = null;

        [DataMember]
        public string link = null;

        [DataMember]
        public string picture = null;

        [DataMember]
        public string gender = null;

        [DataMember]
        public string locale = null;
    }
}
