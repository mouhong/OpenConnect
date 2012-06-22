using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    /// <summary>
    /// Constructs login url based on the application information.
    /// </summary>
    public interface ILoginUrlBuilder
    {
        /// <summary>
        /// Constructs the login url.
        /// </summary>
        /// <param name="appInfo">The application info.</param>
        /// <param name="display">The display mode.</param>
        /// <param name="responseType">The response type.</param>
        /// <returns>The login url.</returns>
        string Build(AppInfo appInfo, string display, ResponseType responseType);
    }
}
