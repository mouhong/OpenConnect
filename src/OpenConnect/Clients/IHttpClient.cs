using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace OpenConnect.Clients
{
    public interface IHttpClient
    {
        string Get(string url, NameValueCollection data, Encoding encoding);

        string Post(string url, NameValueCollection data, Encoding encoding);
    }
}
