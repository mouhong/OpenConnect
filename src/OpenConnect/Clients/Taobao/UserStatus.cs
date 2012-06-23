using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OpenConnect.Clients.Taobao
{
    public enum UserStatus
    {
        Normal = 0,
        Inactive = 1,
        Deleted = 2,
        Frozen = 3,
        Supervised = 4
    }
}
