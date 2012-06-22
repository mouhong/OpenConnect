using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect
{
    /// <summary>
    /// Manages a set of named <see cref="OpenConnect.OpenConnectClient"/>.
    /// </summary>
    public class OpenConnectClientManager
    {
        private Dictionary<string, OpenConnectClient> _clients = new Dictionary<string, OpenConnectClient>();

        public IEnumerable<string> ClientNames
        {
            get
            {
                return _clients.Keys;
            }
        }

        public IEnumerable<OpenConnectClient> Clients
        {
            get
            {
                return _clients.Values;
            }
        }

        public OpenConnectClientManager()
        {
        }

        public OpenConnectClient Find(string name)
        {
            OpenConnectClient client = null;

            if (_clients.TryGetValue(name, out client))
            {
                return client;
            }

            return null;
        }

        public void Add(string name, OpenConnectClient client)
        {
            _clients.Add(name, client);
        }

        public bool Remove(string name)
        {
            return _clients.Remove(name);
        }
    }
}
