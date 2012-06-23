using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using OpenConnect.Utils;

namespace OpenConnect.Clients.Taobao
{
    static class TaobaoApiUtil
    {
        public static string Sign(NameValueCollection apiParams, string appSecret)
        {
            var input = appSecret;

            foreach (var key in apiParams.AllKeys.OrderBy(it => it))
            {
                input += key + apiParams[key];
            }

            input += appSecret;

            return Md5Encryptor.Encrypt(input).ToUpper();
        }
    }
}
