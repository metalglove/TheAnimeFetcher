using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Authentication;
using TheAnimeFetcher.Classes.Helpers;
using TheAnimeFetcher.Classes.Services;
using TheAnimeFetcher.Classes.XML;
using TheAnimeFetcher.Views;

namespace TheAnimeFetcher.Classes.Controllers
{
    public static class LoginController
    {
        private static Navigator Navigator = Navigator.Instance;
        public static async Task<bool> LoginAsync(Credentials credentials)
        {
            User User = await MAL.VerifyCredentials(credentials);
            if (User.IsAllowed)
            {
                Navigator.Navigate(typeof(Home), User);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
