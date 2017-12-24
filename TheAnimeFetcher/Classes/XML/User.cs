using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheAnimeFetcher.Classes.XML
{
    [XmlRoot("user")]
    public class User
    {
        [XmlElement(ElementName = "id")]
        private uint _Id;
        public uint Id { get { return _Id; } set { _Id = value; IsAllowed = true; } }
        private string _Username;
        [XmlElement(ElementName = "username")]
        public string Username { get { return _Username; } set { _Username = value; IsAllowed = true; } }
        // IsAllowed is either set by Username or Id, does not matter.
        public bool IsAllowed { get; set; } = false;
        public NetworkCredential Credentials { get; set; }
    }
}
