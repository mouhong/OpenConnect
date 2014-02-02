using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Live
{
    [DataContract, Serializable]
    public class LiveUserInfo : IUserInfo
    {
        [DataMember] string id = null;
        [DataMember] string name = null;
        [DataMember] string first_name = null;
        [DataMember] string last_name = null;
        [DataMember] int? birth_day = null;
        [DataMember] int? birth_month = null;
        [DataMember] int? birth_year = null;
        [DataMember] string gender = null;
        [DataMember] string link = null;
        [DataMember] string account = null;

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

        public string FirstName
        {
            get
            {
                return first_name;
            }
        }

        public string LastName
        {
            get
            {
                return last_name;
            }
        }

        public string NickName
        {
            get
            {
                return Name;
            }
        }

        public string Avatar
        {
            get
            {
                return null;
            }
        }

        public string Link
        {
            get
            {
                return link;
            }
        }

        public DateTime? Birthday
        {
            get
            {
                if (birth_day != null && birth_month != null && birth_year != null)
                {
                    return new DateTime(birth_year.Value, birth_month.Value, birth_day.Value);
                }

                return null;
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

        public string Email
        {
            get
            {
                return account;
            }
        }

        public LiveUserInfo()
        {
        }

        public override string ToString()
        {
            return name;
        }
    }
}
