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
        public GetUserInfoResultData data = null;
    }

    [DataContract]
    class GetUserInfoResultData
    {
        [DataMember]
        public string name = null;

        [DataMember]
        public string openid = null;

        [DataMember]
        public string nick = null;

        [DataMember]
        public string head = null;

        [DataMember]
        public string location = null;

        [DataMember]
        public string country_code = null;

        [DataMember]
        public string province_code = null;

        [DataMember]
        public string city_code = null;

        [DataMember]
        public int isvip = 0;

        [DataMember]
        public int isent = 0;

        [DataMember]
        public string introduction = null;

        [DataMember]
        public string verifyinfo = null;

        [DataMember]
        public string email = null;

        [DataMember]
        public int birth_year = 0;

        [DataMember]
        public int birth_month = 0;

        [DataMember]
        public int birth_day = 0;

        [DataMember]
        public int sex = 0;

        [DataMember]
        public int fansnum = 0;

        [DataMember]
        public int idolnum = 0;

        [DataMember]
        public int tweetnum = 0;
    }
}
