using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    [Serializable]
    public class ProviderNotFoundException : Exception
    {
        public ProviderNotFoundException()
        {
        }

        public ProviderNotFoundException(string providerName)
            : base("Provider \"" + providerName + "\" was not found.")
        {
        }

        public ProviderNotFoundException(string providerName, Exception inner)
            : base("Provider \"" + providerName + "\" was not found.", inner)
        {
        }

        protected ProviderNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
