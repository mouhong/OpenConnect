using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public interface IOpenConnectProviderFactory
    {
        IEnumerable<string> GetRegisteredProviderNames();

        IOpenConnectProvider GetProvider(string providerInvariantName);

        void Register(string providerInvariantName, Func<IOpenConnectProvider> providerCreator);

        bool Unregister(string providerInvariantName);
    }
}
