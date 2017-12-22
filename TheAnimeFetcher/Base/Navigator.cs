using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAnimeFetcher.Classes.Utils;
using Windows.UI.Xaml.Controls;

namespace TheAnimeFetcher.Base
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
        }
        private void RemoveFromStack()
        {
            if (RootFrame.CanGoBack) RootFrame.BackStack.Remove(RootFrame.BackStack.LastOrDefault());
        }

    }
}
