using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenConnect.Config
{
    public class ClientConfig
    {
        public string Id { get; set; }

        public string AppId { get; set; }

        public string AppSecret { get; set; }

        public string DefaultScope { get; set; }

        public string Type { get; set; }
    }
}
