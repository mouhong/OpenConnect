using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenConnect.Config;
using OpenConnect.Providers;

namespace OpenConnect
{
    public class OpenConnectClientManager
    {
        private List<OpenConnectClient> _clients = new List<OpenConnectClient>();

        public IEnumerable<OpenConnectClient> AllClients
        {
            get
            {
                return _clients;
            }
        }

        public OpenConnectClientManager()
        {
        }

        public bool ContainsClient(string name)
        {
            Check.RequireNotNullOrEmpty(name, "name");

            return _clients.Any(it => it.Name == name);
        }

        public OpenConnectClient FindClient(string name)
        {
            Check.RequireNotNullOrEmpty(name, "name");

            return _clients.FirstOrDefault(it => it.Name == name);
        }

        public void AddClient(OpenConnectClient client)
        {
            Check.RequireNotNull(client, "client");

            if (ContainsClient(client.Name))
                throw new InvalidOperationException("A client with name \"" + client.Name + "\" already exists.");

            _clients.Add(client);
        }

        public bool RemoveClient(string name)
        {
            var client = FindClient(name);

            if (client != null)
            {
                return _clients.Remove(client);
            }

            return false;
        }

        public static OpenConnectClientManager BuildFrom(OpenConnectConfiguration config)
        {
            Check.RequireNotNull(config, "config");

            var manager = new OpenConnectClientManager();

            foreach (var cfg in config.ClientConfigs)
            {
                var client = CreateClient(cfg);
                manager.AddClient(client);
            }

            return manager;
        }

        private static OpenConnectClient CreateClient(ClientConfiguration config)
        {
            var appInfo = new AppInfo(config.AppId, config.AppSecret, config.Scope, config.RedirectUri);
            var providerType = Type.GetType(config.Provider, true);
            var provider = Activator.CreateInstance(providerType) as IOpenConnectProvider;

            if (provider == null)
                throw new InvalidOperationException("Cannot instantiate provider: " + providerType + ".");

            return new OpenConnectClient(config.Name, appInfo, provider);
        }
    }
}
