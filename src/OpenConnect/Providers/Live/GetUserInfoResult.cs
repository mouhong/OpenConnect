using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Live
{
    [DataContract]
    class GetUserInfoResult
    {
        [DataMember]
        public string id = null;

        [DataMember]
        public string name = null;

        [DataMember]
        public string first_name = null;

        [DataMember]
        public string last_name = null;

        [DataMember]
        public string link = null;

        [DataMember]
        public int? birth_day;

        [DataMember]
        public int? birth_month;

        [DataMember]
        public int? birth_year;

        [DataMember]
        public string gender = null;

        [DataMember]
        public string account = null;
    }
}
