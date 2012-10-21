using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OpenConnect.Config
{
   public static class ClientConfigLoader
    {
        public static IList<ClientConfig> LoadFrom(string path)
        {
            Require.NotNullOrEmpty(path, "path");

            if (!File.Exists(path))
                throw new FileNotFoundException("Cannot find client config file: " + path);

            var clients = new List<ClientConfig>();
            var doc = XDocument.Load(path);

            foreach (var clientElement in doc.Root.Elements("client"))
            {
                var id = GetRequiredAttributeValue(clientElement, "id");

                var appId = GetRequiredElementValue(clientElement, "appId");
                var appSecret = GetRequiredElementValue(clientElement, "appSecret");
                var defaultScope = GetElementValueOrDefault(clientElement, "defaultScope");
                var type = GetRequiredElementValue(clientElement, "type");

                clients.Add(new ClientConfig
                {
                    Id = id,
                    AppId = appId,
                    AppSecret = appSecret,
                    DefaultScope = defaultScope,
                    Type = type
                });
            }

            return clients;
        }

        static string GetRequiredAttributeValue(XElement element, string attrName)
        {
            var attr = element.Attribute(attrName);
            if (attr == null || String.IsNullOrWhiteSpace(attr.Value))
                throw new InvalidOperationException("Missing attribute \"" + attrName + "\".");

            return attr.Value;
        }

        static string GetRequiredElementValue(XElement parent, string elementName)
        {
            var element = parent.Element(elementName);
            if (element == null || String.IsNullOrWhiteSpace(element.Value))
                throw new InvalidOperationException("Missing element \"" + elementName + "\".");

            return element.Value;
        }

        static string GetElementValueOrDefault(XElement parent, string elementName)
        {
            var element = parent.Element(elementName);
            return element == null ? null : element.Value;
        }
    }
}
