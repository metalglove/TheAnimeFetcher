using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Data;
using TheAnimeFetcher.Classes.Helpers;
using Windows.UI.Xaml.Controls;

namespace TheAnimeFetcher.Classes.Controllers
{
    public abstract class ControllerBase
    {
        protected static Navigator Navigator = Navigator.Instance;
        protected static UserData UserData = UserData.Instance;
    }
}
