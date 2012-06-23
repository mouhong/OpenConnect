using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Clients.Google
{
    [DataContract]
    public class GoogleUserInfo : IUserInfo
    {
        [DataMember] string id = null;
        [DataMember] string name = null;
        [DataMember] string given_name = null;
        [DataMember] string family_name = null;
        [DataMember] string gender = null;
        [DataMember] string picture = null;
        [DataMember] string link = null;
        [DataMember] string locale = null;

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string GivenName
        {
            get
            {
                return given_name;
            }
        }

        public string FamilyName
        {
            get
            {
                return family_name;
            }
        }

        public string NickName
        {
            get
            {
                return Name;
            }
        }

        public string Email
        {
            get
            {
                return null;
            }
        }

        public string HeadImageUrl
        {
            get
            {
                return picture;
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

                return gender == "male" ? Gender.Male : Gender.Female;
            }
        }

        public string Link
        {
            get
            {
                return link;
            }
        }

        public string Location
        {
            get
            {
                return locale;
            }
        }

        public GoogleUserInfo()
        {
        }

        public override string ToString()
        {
            return name;
        }
    }
}
