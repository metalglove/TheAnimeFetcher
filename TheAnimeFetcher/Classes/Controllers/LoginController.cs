using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Data;
using TheAnimeFetcher.Classes.Services;
using TheAnimeFetcher.Classes.XML;
using TheAnimeFetcher.Views;

namespace TheAnimeFetcher.Classes.Controllers
{
    public class LoginController : ControllerBase
    {
        public static async Task<bool> LoginAsync(NetworkCredential credentials)
        {
            User User = await OfficialMALAPI.VerifyCredentials(credentials);
            if (User.IsAllowed)
            {
                UserData.User = User;
                Navigator.RootFrameNavigate(typeof(Home));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
