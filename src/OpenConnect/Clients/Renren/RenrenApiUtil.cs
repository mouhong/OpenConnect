using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using OpenConnect.Utils;

namespace OpenConnect.Clients.Renren
{
    static class RenrenApiUtil
    {
        public static string Sign(NameValueCollection apiParams, string appSecret)
        {
            var input = String.Empty;

            foreach (var key in apiParams.AllKeys.OrderBy(it => it))
            {
                input += key + "=" + apiParams[key];
            }

            input += appSecret;

            return Md5Encryptor.Encrypt(input);
        }
    }
}
