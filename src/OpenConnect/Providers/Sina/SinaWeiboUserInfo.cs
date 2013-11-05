using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Globalization;

namespace OpenConnect.Providers.Sina
{
    [DataContract, Serializable]
    public class SinaWeiboUserInfo: IUserInfo
    {
        [DataMember] string id = null;
        [DataMember] string screen_name = null;
        [DataMember] string name = null;
        [DataMember] int province = 0;
        [DataMember] int city = 0;
        [DataMember] string location = null;
        [DataMember] string description = null;
        [DataMember] string url = null;
        [DataMember] string profile_image_url = null;
        [DataMember] string domain = null;
        [DataMember] string gender = null;
        [DataMember] int followers_count = 0;
        [DataMember] int friends_count = 0;
        [DataMember] int statuses_count = 0;
        [DataMember] int favourites_count = 0;
        [DataMember] string created_at = null;
        [DataMember] bool following = false;
        [DataMember] bool allow_all_act_msg = false;
        [DataMember] bool geo_enabled = false;
        [DataMember] bool verified = false;
        [DataMember] bool allow_all_comment = false;
        [DataMember] string avatar_large = null;
        [DataMember] string verified_reason = null;
        [DataMember] bool follow_me = false;
        [DataMember] int online_status = 0;
        [DataMember] int bi_followers_count = 0;

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

        public string FriendlyName
        {
            get
            {
                return name;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public string BlogUrl
        {
            get
            {
                return url;
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
                if (gender == "n") return Gender.Unknown;

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

        /// <summary>
        /// 用户的个性化域名。
        /// </summary>
        public string Domain
        {
            get
            {
                return domain;
            }
        }

        public int Province
        {
            get
            {
                return province;
            }
        }

        public int City
        {
            get
            {
                return city;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
        }

        /// <summary>
        /// 粉丝数。
        /// </summary>
        public int FansCount
        {
            get
            {
                return followers_count;
            }
        }

        /// <summary>
        /// 关注数。
        /// </summary>
        public int IdolsCount
        {
            get
            {
                return friends_count;
            }
        }

        /// <summary>
        /// 微博数。
        /// </summary>
        public int TweetsCount
        {
            get
            {
                return statuses_count;
            }
        }

        /// <summary>
        /// 收藏数。
        /// </summary>
        public int FavouritesCount
        {
            get
            {
                return favourites_count;
            }
        }

        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTime CreatedAt
        {
            get
            {
                return DateTime.ParseExact(created_at, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// 当前登录用户是否已关注该用户。
        /// </summary>
        public bool Following
        {
            get
            {
                return following;
            }
        }

        /// <summary>
        /// 是否允许所有人给我发私信。
        /// </summary>
        public bool AllowPrivateMessageFromAnyone
        {
            get
            {
                return allow_all_act_msg;
            }
        }

        /// <summary>
        /// 是否允许带有地理信息。
        /// </summary>
        public bool GeoEnabled
        {
            get
            {
                return geo_enabled;
            }
        }

        /// <summary>
        /// 是否是微博认证用户，即带V用户。
        /// </summary>
        public bool Verified
        {
            get
            {
                return verified;
            }
        }

        /// <summary>
        /// 认证原因。
        /// </summary>
        public string VerifiedReason
        {
            get
            {
                return verified_reason;
            }
        }

        /// <summary>
        /// 是否允许所有人对我的微博进行评论。
        /// </summary>
        public bool AllowCommentsFromAnyone
        {
            get
            {
                return allow_all_comment;
            }
        }

        /// <summary>
        /// 用户大头像地址。
        /// </summary>
        public string LargeHeadImageUrl
        {
            get
            {
                return avatar_large;
            }
        }

        /// <summary>
        /// 该用户是否关注当前登录用户。
        /// </summary>
        public bool FollowMe
        {
            get
            {
                return follow_me;
            }
        }

        public bool IsOnline
        {
            get
            {
                return online_status == 1;
            }
        }

        /// <summary>
        /// 用户的互粉数。
        /// </summary>
        public int BiFollowersCount
        {
            get
            {
                return bi_followers_count;
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
