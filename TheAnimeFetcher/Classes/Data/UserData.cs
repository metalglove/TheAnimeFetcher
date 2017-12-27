using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Helpers;
using TheAnimeFetcher.Classes.JSON;
using TheAnimeFetcher.Classes.XML;

namespace TheAnimeFetcher.Classes.Data
{
    public class UserData : Singleton<UserData>
    {
        public User User { get; set; } = new User();
        public CookieContainer CookieContainer { get; set; } = new CookieContainer();
        public AnimeList AnimeList { get; set; }
        public MangaList MangaList { get; set; }
        public bool AnimeListChanged { get; set; } = false;
        public bool MangaListChanged { get; set; } = false;
    }
}
