using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Utils
{
    static class UrlUtility
    {
        public static string Combine(string url1, string url2)
        {
            if (String.IsNullOrEmpty(url1))
            {
                return url2;
            }
            if (String.IsNullOrEmpty(url2))
            {
                return url1;
            }

            url1 = url1.TrimEnd('/');
            url2 = url2.TrimStart('/');

            return url1 + "/" + url2;
        }
    }
}
