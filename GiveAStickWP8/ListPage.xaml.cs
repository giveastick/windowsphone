using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Collections;

namespace GiveAStickWP8
{
    public partial class ListPage : PhoneApplicationPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        private void stickItemTap(Object sender, System.Windows.Input.GestureEventArgs e)
        {
            Stick s = ((sender as ListBox).SelectedItem as Stick);

            if (s != null)
            {
                MessageBox.Show(s.Nickname);
            }
        }


        private void RefreshList(object sender, EventArgs e)
        {
            Uri u = new Uri("/ListPage.xaml", UriKind.Relative);
            App.RootFrame.Navigate(u);
        }

        private void Logout(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxResult.OK == MessageBox.Show("Voulez-vous vraiment vous déconnecter ?", "Déconnexion", MessageBoxButton.OKCancel))
                {
                    Uri u = new Uri("/MainPage.xaml", UriKind.Relative);
                    App.RootFrame.Navigate(u);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de déconnexion du compte.");
            }
        }
    }
}