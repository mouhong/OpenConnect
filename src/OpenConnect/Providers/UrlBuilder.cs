using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;

namespace OpenConnect.Providers
{
    public class UrlBuilder
    {
        public string Path { get; private set; }

        public bool IgnoreEmptyValue { get; set; }

        public NameValueCollection Parameters { get; private set; }

        public UrlBuilder(string path)
        {
            Require.NotNullOrEmpty(path, "path");

            Path = path;
            Parameters = new NameValueCollection();
            IgnoreEmptyValue = true;
        }

        public static UrlBuilder Create(string path)
        {
            return new UrlBuilder(path);
        }

        public UrlBuilder WithParam(string name, string value)
        {
            Require.NotNullOrEmpty(name, "name");

            Parameters[name] = value ?? String.Empty;

            return this;
        }

        public string Build()
        {
            if (Parameters.Count == 0)
            {
                return Path;
            }

            var sb = new StringBuilder();
            sb.Append(Path).Append("?");

            var first = true;

            foreach (string key in Parameters.AllKeys)
            {
                var value = Parameters[key];

                if (IgnoreEmptyValue && String.IsNullOrEmpty(value)) continue;

                if (!first)
                {
                    sb.Append("&");
                }
                sb.AppendFormat("{0}={1}", key, Uri.EscapeDataString(Parameters[key]));

                first = false;
            }

            return sb.ToString();
        }
    }
}
