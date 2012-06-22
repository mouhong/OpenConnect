using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace OpenConnect.Utils
{
    static class Md5Encryptor
    {
        public static string Encrypt(string input)
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
