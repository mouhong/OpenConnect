using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Web;

namespace OpenConnect.Providers
{
    public class HttpClient : IHttpClient
    {
        public static readonly HttpClient Instance = new HttpClient();

        public string Get(string url, NameValueCollection data, Encoding encoding)
        {
            Require.NotNullOrEmpty(url, "url");
            Require.NotNull(encoding, "encoding");

            if (data != null)
            {
                var qs = RequestDataToString(data);

                if (!String.IsNullOrEmpty(qs))
                {
                    if (url.IndexOf('?') > 0)
                    {
                        url += "&" + qs;
                    }
                    else
                    {
                        url += "?" + qs;
                    }
                }
            }

            using (var client = new WebClient())
            {
                client.Encoding = encoding;
                return client.DownloadString(url);
            }
        }

        public string Post(string url, NameValueCollection data, Encoding encoding)
        {
            Require.NotNullOrEmpty(url, "url");
            Require.NotNull(encoding, "encoding");

            using (var client = new WebClient())
            {
                client.Encoding = encoding;
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                byte[] bytes = null;

                if (data != null)
                {
                    bytes = encoding.GetBytes(RequestDataToString(data));
                }

                var response = client.UploadData(url, "POST", bytes);

                return encoding.GetString(response);
            }
        }

        private string RequestDataToString(NameValueCollection nv)
        {
            var result = new StringBuilder();
            var first = true;

            foreach (var key in nv.AllKeys)
            {
                if (!first)
                {
                    result.Append("&");
                }

                var value = nv[key];

                if (!String.IsNullOrEmpty(value))
                {
                    value = Uri.EscapeDataString(value);
                }

                result.AppendFormat("{0}={1}", key, value);

                first = false;
            }

            return result.ToString();
        }
    }
}
