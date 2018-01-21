using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TheAnimeFetcher.Classes.HTML;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TheAnimeFetcher.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecommendationsControl : Page
    {
        public Recommendations Recommendations { get; set; }
        public RecommendationsControl()
        {
            this.InitializeComponent();
            DataContext = this;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Recommendations = e.Parameter as Recommendations;
            LVAnime.ItemsSource = Recommendations.AnimeRecommendations;//TODO: make method async so the controls will be loaded with the UI interactive
            LVManga.ItemsSource = Recommendations.MangaRecommendations;//TODO: make method async so the controls will be loaded with the UI interactive
        }
    }
}
