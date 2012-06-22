using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public interface ILoginUrlBuilder
    {
        string Build(AppInfo appInfo, string display, ResponseType responseType);
    }
}
