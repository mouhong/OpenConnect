using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace OpenConnect.Providers.Renren
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

            return MD5Hash(input);
        }

        private static string MD5Hash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            var result = String.Empty;

            foreach (var each in hash)
            {
                result += each.ToString("x2");
            }

            return result;
        }
    }
}
