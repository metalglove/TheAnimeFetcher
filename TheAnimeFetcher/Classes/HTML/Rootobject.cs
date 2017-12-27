using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAnimeFetcher.Classes.HTML
{
    public class Rootobject
    {
        public List<Item> recommended_animes { get; set; }
        public List<Item> recommended_mangas { get; set; }
    }
    public class Item
    {
        public int id { get; set; }
        public string title { get; set; }
        public string path { get; set; }
        public string image { get; set; }
        public string bundle { get; set; }
    }
}
