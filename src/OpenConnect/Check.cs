using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    class Check
    {
        public static void Require(bool condition, string message)
        {
            if (!condition)
                throw new ArgumentException(message);
        }

        public static void RequireNotNull(object value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        public static void RequireNotNullOrEmpty(string value, string paramName)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException(String.Format("'{0}' is required.", paramName));
        }
    }
}
