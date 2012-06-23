using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Clients.Renren
{
    [DataContract]
    public class RenrenUserInfo : IUserInfo
    {
        [DataMember] string uid = null;
        [DataMember] string name = null;
        [DataMember] string sex = null;
        [DataMember] string headurl = null;

        public string Id
        {
            get
            {
                return uid;
            }
        }

        public string NickName
        {
            get
            {
                return name;
            }
        }

        public Gender Gender
        {
            get
            {
                return sex == "1" ? Gender.Male : (sex == "2" ? Gender.Female : Gender.Unknown);
            }
        }

        public string HeadImageUrl
        {
            get
            {
                return headurl;
            }
        }

        public string Email
        {
            get
            {
                return null;
            }
        }

        public RenrenUserInfo()
        {
        }

        public override string ToString()
        {
            return name;
        }
    }
}
