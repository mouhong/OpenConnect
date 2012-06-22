using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    /// <summary>
    /// Represents the expected response type from the authorization server.
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// Used in authorization code grant flow.
        /// </summary>
        Code = 0,

        /// <summary>
        /// Used in implicit grant flow.
        /// </summary>
        Token = 1
    }
}
