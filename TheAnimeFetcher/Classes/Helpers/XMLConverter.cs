using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TheAnimeFetcher.Classes.Helpers
{
    public static class XMLConverter
    {
        public static T DeserializeXmlAsStringToClass<T>(string XmlAsString)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(new StringReader(XmlAsString));
        }
        public static object DeserializeXmlAsStringToClass(string XmlAsString, Type Type)
        {
            return new XmlSerializer(Type).Deserialize(new StringReader(XmlAsString));
        }
        public static XmlDocument DeserializeClassToXml<T>(T Class)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlDocument classDoc = null;

            using (MemoryStream memStm = new MemoryStream())
            {
                serializer.Serialize(memStm, Class);
                memStm.Position = 0;
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                using (XmlReader xtr = XmlReader.Create(memStm, settings))
                {
                    classDoc = new XmlDocument();
                    classDoc.Load(xtr);
                }
            }

            return classDoc;
        }
    }
}
