using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Clients.Tencent.QQ
{
    [DataContract]
    public class QQUserInfo : IUserInfo
    {
        [DataMember] string nickname = null;
        [DataMember] string figureurl = null;
        [DataMember] string gender = null;

        [IgnoreDataMember]
        public string Id { get; internal set; }

        public string NickName
        {
            get
            {
                return nickname;
            }
        }

        public string HeadImageUrl
        {
            get
            {
                return figureurl;
            }
        }

        public Gender Gender
        {
            get
            {
                if (String.IsNullOrEmpty(gender))
                {
                    return Gender.Unknown;
                }

                return gender == "男" ? Gender.Male : Gender.Female;
            }
        }

        public string Email
        {
            get
            {
                return null;
            }
        }

        public QQUserInfo()
        {
        }

        public override string ToString()
        {
            return NickName;
        }
    }
}
