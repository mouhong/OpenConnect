using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Tencent.QQ
{
    [DataContract, Serializable]
    public class QQUserInfo : IUserInfo
    {
        [DataMember] string nickname = null;
        [DataMember] string figureurl_2 = null;
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

        public string Avatar
        {
            get
            {
                return figureurl_2;
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
