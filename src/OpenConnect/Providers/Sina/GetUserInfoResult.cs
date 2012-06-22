using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Weibo
{
    [DataContract]
    class GetUserInfoResult
    {
        [DataMember]
        public string id = null;

        [DataMember]
        public string screen_name = null;

        [DataMember]
        public string gender = null;

        [DataMember]
        public string profile_image_url = null;

        public UserInfo ToUserInfo()
        {
            return new UserInfo
            {
                Id = id,
                NickName = screen_name,
                Gender = gender == "m" ? Gender.Male : Gender.Female,
                HeadImageUrl = profile_image_url
            };
        }
    }
}
