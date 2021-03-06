﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using TheAnimeFetcher.Classes.Controllers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TheAnimeFetcher.Views
{
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private async void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbUser.Text == "" || pbPassword.Password == "")
            {
                SetBorderBrushes();
                return;
            }
            if (!await LoginController.LoginAsync(new NetworkCredential() { UserName = tbUser.Text, Password = pbPassword.Password }))
            {
                SetBorderBrushes();
            }
        }
        private void SetBorderBrushes()
        {
            tbUser.BorderBrush = new SolidColorBrush(Colors.Red);
            pbPassword.BorderBrush = new SolidColorBrush(Colors.Red);
        }
    }
}
