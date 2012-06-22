using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Providers.Taobao
{
    [DataContract]
    public class TaobaoUserInfo : IUserInfo
    {
        [DataMember] string uid = null;
        [DataMember] string nick = null;
        [DataMember] string sex = null;
        [DataMember] UserCredit buyer_credit = null;
        [DataMember] UserCredit seller_credit = null;
        [DataMember] Location location = null;
        [DataMember] string type = null;
        [DataMember] string avatar = null;
        [DataMember] bool has_shop = false;
        [DataMember] bool is_golden_seller = false;
        [DataMember] string vip_info = null;
        [DataMember] string email = null;
        [DataMember] string status = null;

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
                return nick;
            }
        }

        public Gender Gender
        {
            get
            {
                return String.IsNullOrEmpty(sex) ? Gender.Unknown : (sex == "m" ? Gender.Male : Gender.Female);
            }
        }

        public UserCredit BuyerCredit
        {
            get
            {
                return buyer_credit;
            }
        }

        public UserCredit SellerCredit
        {
            get
            {
                return seller_credit;
            }
        }

        public Location Location
        {
            get
            {
                return location;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
        }

        public string HeadImageUrl
        {
            get
            {
                return avatar;
            }
        }

        public bool HasShop
        {
            get
            {
                return has_shop;
            }
        }

        public bool IsGoldenSeller
        {
            get
            {
                return is_golden_seller;
            }
        }

        public string VipInfo
        {
            get
            {
                return vip_info;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
        }

        public UserStatus? Status
        {
            get
            {
                if (String.IsNullOrEmpty(status))
                {
                    return null;
                }

                if (status == "inactive")
                {
                    return UserStatus.Inactive;
                }

                if (status == "delete")
                {
                    return UserStatus.Deleted;
                }

                if (status == "freeze")
                {
                    return UserStatus.Frozen;
                }

                if (status == "supervise")
                {
                    return UserStatus.Supervised;
                }

                return UserStatus.Normal;
            }
        }

        public TaobaoUserInfo()
        {
        }
    }
}
