using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Tencent.QQ
{
    [DataContract]
    class GetUserInfoResult
    {
        [DataMember]
        public int ret = 0;

        [DataMember]
        public string msg = null;

        [DataMember]
        public string nickname = null;

        [DataMember]
        public string figureurl = null;

        [DataMember]
        public string gender = null;

        public UserInfo ToUserInfo()
        {
            return new UserInfo
            {
                NickName = nickname,
                HeadImageUrl = figureurl,
                Gender = gender == "男" ? Gender.Male : Gender.Female
            };
        }
    }
}
