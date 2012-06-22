using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Config
{
    public class OpenConnectConfiguration
    {
        private List<ClientConfiguration> _clientConfigs = new List<ClientConfiguration>();

        public IEnumerable<ClientConfiguration> ClientConfigs
        {
            get
            {
                return _clientConfigs;
            }
        }

        public OpenConnectConfiguration()
        {
        }

        public static OpenConnectConfiguration From(string filePath)
        {
            return OpenConnectConfigurationReader.ReadFrom(filePath);
        }

        public bool ContainsClientConfig(string name)
        {
            return _clientConfigs.Any(it => it.Name == name);
        }

        public void AddClientConfig(ClientConfiguration config)
        {
            Require.NotNull(config, "config");
            Require.That(!ContainsClientConfig(config.Name), "A client with name \"" + config.Name + "\" already exists.");

            _clientConfigs.Add(config);
        }

        public bool RemoveClientConfig(string name)
        {
            var config = FindClientConfig(name);

            if (config != null)
            {
                return _clientConfigs.Remove(config);
            }

            return false;
        }

        public ClientConfiguration FindClientConfig(string name)
        {
            Require.NotNullOrEmpty(name, "name");

            return _clientConfigs.FirstOrDefault(it => it.Name == name);
        }
    }
}
