using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TheAnimeFetcher.Classes.Constants.Enumerations;
using TheAnimeFetcher.Classes.Controllers;
using TheAnimeFetcher.Classes.Helpers;
using TheAnimeFetcher.Classes.JSON;
using TheAnimeFetcher.Classes.XML;
using TheAnimeFetcher.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TheAnimeFetcher.Views
{
    public sealed partial class Home : Page
    {
        public RecommendedList RecommendedList { get; private set; }
        public AnimeList AnimeList { get; private set; }
        public MangaList MangaList { get; private set; }
        public Classes.XML.Anime Anime { get; private set; }
        public Classes.XML.Manga Manga { get; private set; }
        public Search Search { get; private set; }
        public Recent Recent { get; private set; }
        public Home()
        {
            this.InitializeComponent();
            HomeController.SetContentFrame(ContentFrame);
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //Anime = await HomeController.SearchAnime("Naruto");
            //Manga = await HomeController.SearchManga("Naruto");
            //Search = await HomeController.SearchMAL("Naruto", UnofficialMALSearchType.All);
            //RecommendedList = await HomeController.GetRecommendationsFor(RecommendationsType.Anime);
            //AnimeList = await HomeController.GetAnimeList();
            //MangaList = await HomeController.GetMangaList();
            Recent = await HomeController.GetRecentsFor(RecentType.Anime_by_episode);
            //Recent = await HomeController.GetRecentsFor(RecentType.Anime, "Kineta");
            //HomeController.ContentFrameNavigate(typeof(AnimeListControl), AnimeList);
            //HomeController.ContentFrameNavigate(typeof(MangaListControl), MangaList);
            //HomeController.ContentFrameNavigate(typeof(RecommendationsControl), RecommendedList);
        }
    }
}
