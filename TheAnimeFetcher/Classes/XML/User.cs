using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheAnimeFetcher.Classes.XML
{
    public class User
    {
        [XmlAttribute(AttributeName = "id")]
        public uint Id { get; set; }
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }
    }
}
