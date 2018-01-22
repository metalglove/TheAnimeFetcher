using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Constants.Enumerations;

namespace TheAnimeFetcher.Classes.JSON
{
    public class RecommendedList : ObservableCollection<Recommended>
    {
        public RecommendationsType RecommendationsType { get; set; }
        public string RecommendedTitle { get { return RecommendationsType.GetValue(); } }
    }
}
