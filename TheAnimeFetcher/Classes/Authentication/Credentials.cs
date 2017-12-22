using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Helpers;
using TheAnimeFetcher.Classes.XML;

namespace TheAnimeFetcher.Classes.Authentication
{
    public class Credentials
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Credentials(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
