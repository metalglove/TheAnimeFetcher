using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TheAnimeFetcher.Classes.Helpers
{
    public class Navigator : Singleton<Navigator>
    {
        private Frame RootFrame { get; set; }

        public void SetRootFrame(Frame frame)
        {
            RootFrame = frame;
        }
        public void Navigate(Type page, object parameter)
        {
            RootFrame.Navigate(page, parameter);
            RemoveFromStack();
            SetTitle(page.Name);
        }
        public void Navigate(Type page)
        {
            RootFrame.Navigate(page);
            RemoveFromStack();
            SetTitle(page.Name);
        }
        private void SetTitle(string title)
        {
            ApplicationView.GetForCurrentView().Title = title;
        }
        private void RemoveFromStack()
        {
            if (RootFrame.CanGoBack) RootFrame.BackStack.Remove(RootFrame.BackStack.LastOrDefault());
        }

    }
}
