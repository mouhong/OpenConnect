using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OpenConnect.Utils
{
    class JsonSerializer
    {
        public static string Serialize(object obj)
        {
            if (obj == null) return null;

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());

            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);

                stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static object Deserialize(string json, Type objType)
        {
            Check.RequireNotNull(objType, "objType");

            if (String.IsNullOrEmpty(json)) return null;

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(objType);

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(json);
                writer.Flush();

                stream.Seek(0, SeekOrigin.Begin);

                return serializer.ReadObject(stream);
            }
        }
    }
}
