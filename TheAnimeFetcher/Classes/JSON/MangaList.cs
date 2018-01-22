using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Controls;

namespace TheAnimeFetcher.Classes.JSON
{
    public class MangaList : ObservableCollection<Manga>
    {

    }
    public static class MangaListExtensions
    {
        public static ObservableCollection<MangaControl> ConvertToControls(this MangaList MangaList)
        {
            ObservableCollection<MangaControl> ocMangaControls = new ObservableCollection<MangaControl>();
            foreach (Manga Manga in MangaList)
            {
                ocMangaControls.Add(new MangaControl(Manga));
            }
            return ocMangaControls;
        }
    }
}
