using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TheAnimeFetcher.Classes.Services.Enumerations;
using TheAnimeFetcher.Classes.Controllers;
using TheAnimeFetcher.Classes.Helpers;
using TheAnimeFetcher.Classes.HTML;
using TheAnimeFetcher.Classes.JSON;
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
        public Recommendations Recommendations { get; private set; }
        public AnimeList AnimeList { get; private set; }
        public MangaList MangaList { get; private set; }
        public Home()
        {
            this.InitializeComponent();
            HomeController.SetContentFrame(ContentFrame);
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //Classes.XML.Anime Animes = await HomeController.SearchAnime("Naruto");
            Classes.XML.Manga Mangas = await HomeController.SearchManga("Naruto");
            //Search SearchResult = await HomeController.SearchMAL("Naruto", UnofficialMALSearchType.All);
            //Recommendations = await HomeController.GetRecommendations();
            //AnimeList = await HomeController.GetAnimeList();
            //MangaList = await HomeController.GetMangaList();
            //HomeController.ContentFrameNavigate(typeof(AnimeListControl), AnimeList);
            //HomeController.ContentFrameNavigate(typeof(MangaListControl), MangaList);
            //HomeController.ContentFrameNavigate(typeof(RecommendationsControl), Recommendations);
        }
    }
}
