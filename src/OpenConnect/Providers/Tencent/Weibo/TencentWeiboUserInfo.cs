using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Tencent.Weibo
{
    [DataContract, Serializable]
    public class TencentWeiboUserInfo : IUserInfo
    {
        [DataMember] string name = null;
        [DataMember] string openid = null;
        [DataMember] string nick = null;
        [DataMember] string head = null;
        [DataMember] string location = null;
        [DataMember] string country_code = null;
        [DataMember] string province_code = null;
        [DataMember] string city_code = null;
        [DataMember] int isvip = 0;
        [DataMember] int isent = 0;
        [DataMember] string introduction = null;
        [DataMember] string verifyinfo = null;
        [DataMember] string email = null;
        [DataMember] int birth_year = 0;
        [DataMember] int birth_month = 0;
        [DataMember] int birth_day = 0;
        [DataMember] int sex = 0;
        [DataMember] int fansnum = 0;
        [DataMember] int idolnum = 0;
        [DataMember] int tweetnum = 0;
        [DataMember] int favnum = 0;
        [DataMember] int isrealname = 0;
        [DataMember] long regtime = 0;
        [DataMember] IList<TencentWeiboTag> tag = null;

        public string Id
        {
            get
            {
                return openid;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string NickName
        {
            get
            {
                return nick;
            }
        }

        public string Avatar
        {
            get
            {
                return head + "/100";
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
        }

        public Gender Gender
        {
            get
            {
                return sex == 1 ? Gender.Male : (sex == 2 ? Gender.Female : Gender.Unknown);
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
        }

        public string CountryCode
        {
            get
            {
                return country_code;
            }
        }

        public string ProvinceCode
        {
            get
            {
                return province_code;
            }
        }

        public string CityCode
        {
            get
            {
                return city_code;
            }
        }

        public bool IsVip
        {
            get
            {
                return isvip == 1;
            }
        }

        public bool IsEnterprice
        {
            get
            {
                return isent == 1;
            }
        }

        public string Introduction
        {
            get
            {
                return introduction;
            }
        }

        public string VerificationInfo
        {
            get
            {
                return verifyinfo;
            }
        }

        public int FansCount
        {
            get
            {
                return fansnum;
            }
        }

        public int IdolsCount
        {
            get
            {
                return idolnum;
            }
        }

        public int TweetsCount
        {
            get
            {
                return tweetnum;
            }
        }

        public int FavoriteTweetsCount
        {
            get
            {
                return favnum;
            }
        }

        public bool IsRealNameVerified
        {
            get
            {
                return isrealname == 1;
            }
        }

        public DateTime CreatedTime
        {
            get
            {
                return new DateTime(1970, 1, 1).AddSeconds(regtime);
            }
        }

        public DateTime? Birthday
        {
            get
            {
                if (birth_year > 0 && birth_month > 0 && birth_day > 0)
                {
                    return new DateTime(birth_year, birth_month, birth_day);
                }

                return null;
            }
        }

        public IList<TencentWeiboTag> Tags
        {
            get
            {
                if (tag == null)
                {
                    tag = new List<TencentWeiboTag>();
                }

                return tag;
            }
        }

        public TencentWeiboUserInfo()
        {
        }

        public override string ToString()
        {
            return NickName;
        }
    }

    [DataContract, Serializable]
    public class TencentWeiboTag
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
