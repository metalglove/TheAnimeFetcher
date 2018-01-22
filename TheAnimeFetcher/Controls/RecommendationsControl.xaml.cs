using System;
using System.Collections.Generic;
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
    public sealed partial class RecommendationsControl : Page
    {
        public RecommendedList RecommendedList { get; set; }
        public RecommendationsControl()
        {
            this.InitializeComponent();
            DataContext = this;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RecommendedList = e.Parameter as RecommendedList;
            LVAnime.ItemsSource = RecommendedList;//TODO: make method async so the controls will be loaded with the UI interactive
        }
    }
}
