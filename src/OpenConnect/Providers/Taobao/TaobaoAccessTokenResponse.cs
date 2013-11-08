using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers.Taobao
{
    public class TaobaoAccessTokenResponse : AccessTokenResult
    {
        public string UserNick { get; set; }
    }
}
