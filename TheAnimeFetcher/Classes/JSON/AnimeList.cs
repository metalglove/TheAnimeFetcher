using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Controls;

namespace TheAnimeFetcher.Classes.JSON
{
    public class AnimeList : ObservableCollection<Anime>
    {
        
    }
    public static class AnimeListExtensions
    {
        public static ObservableCollection<AnimeControl> ConvertToControls(this AnimeList AnimeList)
        {
            ObservableCollection<AnimeControl> ocAnimeControls = new ObservableCollection<AnimeControl>();
            foreach (Anime Anime in AnimeList)
            {
                ocAnimeControls.Add(new AnimeControl(Anime));
            }
            return ocAnimeControls;
        }
    }
}
