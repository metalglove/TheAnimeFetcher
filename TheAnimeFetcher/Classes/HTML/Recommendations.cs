using System.Collections.Generic;

namespace TheAnimeFetcher.Classes.HTML
{
    public class Recommendations
    {
        public List<Item> AnimeRecommendations { get; set; } = new List<Item>();
        public List<Item> MangaRecommendations { get; set; } = new List<Item>();
    }
}