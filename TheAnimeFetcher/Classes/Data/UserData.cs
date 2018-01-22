using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Constants.Enumerations;
using TheAnimeFetcher.Classes.Helpers;
using TheAnimeFetcher.Classes.JSON;
using TheAnimeFetcher.Classes.XML;

namespace TheAnimeFetcher.Classes.Data
{
    public class UserData : Singleton<UserData>
    {
        public User User { get; set; } = new User();
        public CookieContainer CookieContainer { get; set; } = new CookieContainer();
        public string CSRF_Token { get; set; }
        public AnimeList AnimeList { get; set; }
        public MangaList MangaList { get; set; }
        public string Placement_personalized_anime { private get; set; }
        public string Placement_personalized_manga { private get; set; }
        public string GetPlacementFor(RecommendationsType recommendationsType)
        {
            switch (recommendationsType)
            {
                case RecommendationsType.Anime:
                    return Placement_personalized_anime;
                case RecommendationsType.Manga:
                    return Placement_personalized_manga;
                default:
                    throw new ArgumentException("Out of recommendationsType range");
            }
        }
        public bool AnimeListChanged { get; set; } = false;
        public bool MangaListChanged { get; set; } = false;
    }
}
