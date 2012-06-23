using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenConnect.Clients;

namespace OpenConnect
{
    /// <summary>
    /// Manages a set of named <see cref="T:OpenConnect.Clients.IOpenConnectClient"/>.
    /// </summary>
    public class OpenConnectClientManager
    {
        private Dictionary<string, IOpenConnectClient> _clients = new Dictionary<string, IOpenConnectClient>();

        public IEnumerable<string> ClientNames
        {
            get
            {
                return _clients.Keys;
            }
        }

        public IEnumerable<IOpenConnectClient> Clients
        {
            get
            {
                return _clients.Values;
            }
        }

        public OpenConnectClientManager()
        {
        }

        public IOpenConnectClient Find(string name)
        {
            IOpenConnectClient client = null;

            if (_clients.TryGetValue(name, out client))
            {
                return client;
            }

            return null;
        }

        public void Add(string name, IOpenConnectClient client)
        {
            _clients.Add(name, client);
        }

        public bool Remove(string name)
        {
            return _clients.Remove(name);
        }
    }
}
