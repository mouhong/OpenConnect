using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace OpenConnect
{
    static class NameValueCollectionExtensions
    {
        public static NameValueCollection FluentAdd(this NameValueCollection nv, string name, string value)
        {
            Require.NotNull(nv, "nv");
            Require.NotNullOrEmpty(name, "name");

            nv.Add(name, value);
            return nv;
        }

        public static NameValueCollection AddIfValueIsNotNullOrEmpty(this NameValueCollection nv, string name, string value)
        {
            Require.NotNull(nv, "nv");
            Require.NotNullOrEmpty(name, "name");

            if (!String.IsNullOrEmpty(value))
            {
                nv.Add(name, value);
            }

            return nv;
        }
    }
}
