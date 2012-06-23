using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Sina
{
    [DataContract]
    public class SinaWeiboUserInfo: IUserInfo
    {
        [DataMember] string id = null;
        [DataMember] string screen_name = null;
        [DataMember] string gender = null;
        [DataMember] string profile_image_url = null;

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string NickName
        {
            get
            {
                return screen_name;
            }
        }

        public string Email
        {
            get
            {
                return null;
            }
        }

        public Gender Gender
        {
            get
            {
                return gender == "m" ? Gender.Male : Gender.Female;
            }
        }

        public string HeadImageUrl
        {
            get
            {
                return profile_image_url;
            }
        }

        public SinaWeiboUserInfo()
        {
        }

        public override string ToString()
        {
            return NickName;
        }
    }
}
