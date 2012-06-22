using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace OpenConnect.Config
{
    class OpenConnectConfigurationReader
    {
        public static OpenConnectConfiguration ReadFrom(string filePath)
        {
            Require.NotNullOrEmpty(filePath, "filePath");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Cannot find OpenConnect configuration file in specified location.", filePath);

            return ReadFrom(XDocument.Load(filePath));
        }

        public static OpenConnectConfiguration ReadFrom(XDocument doc)
        {
            var config = new OpenConnectConfiguration();

            foreach (var clientElement in doc.Root.Elements("client"))
            {
                var name = GetRequiredElementValue(clientElement, "name");
                var appId = GetRequiredElementValue(clientElement, "appId");
                var appSecret = GetRequiredElementValue(clientElement, "appSecret");
                var redirectUri = GetRequiredElementValue(clientElement, "redirectUri");
                var provider = GetRequiredElementValue(clientElement, "provider");

                string scope = null;

                var scopeElement = clientElement.Element("scope");
                if (scopeElement != null)
                {
                    scope = scopeElement.Value.Trim();
                }

                config.AddClientConfig(new ClientConfiguration(name, appId, appSecret, scope, redirectUri, provider));
            }

            return config;
        }

        private static string GetRequiredElementValue(XElement parent, string elementName)
        {
            var element = parent.Element(elementName);

            if (element == null)
                throw new ConfigurationException("Missing \"" + elementName + "\" element in OpenConnect configuration file.");

            var value = element.Value;

            if (String.IsNullOrEmpty(value))
                throw new ConfigurationException("The value of \"" + elementName + "\" element cannot be empty.");

            return value;
        }
    }
}
