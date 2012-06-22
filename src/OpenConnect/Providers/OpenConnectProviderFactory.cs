using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Providers
{
    public class OpenConnectProviderFactory : IOpenConnectProviderFactory
    {
        private Dictionary<string, Func<IOpenConnectProvider>> _providers = new Dictionary<string, Func<IOpenConnectProvider>>();

        public OpenConnectProviderFactory()
        {
        }

        public IEnumerable<string> GetRegisteredProviderNames()
        {
            return _providers.Keys;
        }

        public IOpenConnectProvider GetProvider(string providerInvariantName)
        {
            Func<IOpenConnectProvider> creator = null;

            if (_providers.TryGetValue(providerInvariantName, out creator))
            {
                return creator();
            }

            return null;
        }

        public void Register(string providerInvariantName, Func<IOpenConnectProvider> providerCreator)
        {
            Require.NotNullOrEmpty(providerInvariantName, "providerInvariantName");
            Require.NotNull(providerCreator, "providerCreator");

            if (_providers.ContainsKey(providerInvariantName))
                throw new InvalidOperationException("There's already a provider registered with name \"" + providerInvariantName + "\".");

            _providers.Add(providerInvariantName, providerCreator);
        }

        public bool Unregister(string providerInvariantName)
        {
            Require.NotNullOrEmpty(providerInvariantName, "providerInvariantName");

            return _providers.Remove(providerInvariantName);
        }
    }
}
