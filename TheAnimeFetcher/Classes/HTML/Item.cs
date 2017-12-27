using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAnimeFetcher.Classes.HTML
{
    public abstract class Item
    {
        protected int id { get; set; }
        protected string title { get; set; }
        protected string path { get; set; }
        protected string image { get; set; }
        protected string bundle { get; set; }
    }
}
