using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Helpers;

namespace TheAnimeFetcher.Classes.Controllers
{
    public abstract class ControllerBase
    {
        protected static Navigator Navigator = Navigator.Instance;
    }
}
