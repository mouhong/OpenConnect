using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Tencent
{
    public class TencentAccessTokenResponse : AccessTokenResponse
    {
        public string UserName { get; set; }
    }
}
