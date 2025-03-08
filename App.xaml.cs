using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace dam.mvvm.sqlite
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}