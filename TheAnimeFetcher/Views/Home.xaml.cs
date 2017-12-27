using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TheAnimeFetcher.Classes.Controllers;
using TheAnimeFetcher.Classes.Helpers;
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
        public AnimeList AnimeList { get; set; }
        public MangaList MangaList { get; set; }
        public Home()
        {
            this.InitializeComponent();
            HomeController.SetContentFrame(ContentFrame);
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //Recommandations = await HomeController.GetRecommendations();
            AnimeList = await HomeController.GetAnimeList();
            MangaList = await HomeController.GetMangaList();
            HomeController.ContentFrameNavigate(typeof(AnimeListControl), AnimeList);
        }
    }
}
