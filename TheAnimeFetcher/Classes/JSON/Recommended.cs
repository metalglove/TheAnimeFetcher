using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Constants.Enumerations;

namespace TheAnimeFetcher.Classes.JSON
{
    public class Recommended
    {
        public RecommendationsType Type { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string path { get; set; }
        public string image { get; set; }
        public string bundle { get; set; }
    }
}
