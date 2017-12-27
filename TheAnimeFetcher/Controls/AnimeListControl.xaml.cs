using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TheAnimeFetcher.Classes.JSON;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TheAnimeFetcher.Controls
{
    public sealed partial class AnimeListControl : Page
    {
        public AnimeListControl()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AnimeList animeList = e.Parameter as AnimeList;
            lvAnimeList.ItemsSource = animeList.ConvertToControls();//TODO: make method async so the controls will be loaded with the UI interactive
        }
        
    }
}
