using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    class Require
    {
        public static void That(bool condition, string message)
        {
            if (!condition)
                throw new ArgumentException(message);
        }

        public static void NotNull(object value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        public static void NotNullOrEmpty(string value, string paramName)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException(String.Format("'{0}' is required.", paramName));
        }
    }
}
