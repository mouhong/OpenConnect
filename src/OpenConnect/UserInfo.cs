using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect
{
    [Serializable]
    public class UserInfo
    {
        public string Id { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string HeadImageUrl { get; set; }

        public Gender Gender { get; set; }

        public UserInfo()
        {
        }
    }
}
