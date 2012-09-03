using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Clients.Taobao
{
    [DataContract, Serializable]
    public class UserCredit
    {
        [DataMember] int level = 0;
        [DataMember] int score = 0;
        [DataMember] int total_num = 0;
        [DataMember] int good_num = 0;

        public int Level
        {
            get
            {
                return level;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
        }

        public int TotalReviews
        {
            get
            {
                return total_num;
            }
        }

        public int GoodReviews
        {
            get
            {
                return good_num;
            }
        }

        public UserCredit()
        {
        }
    }
}
