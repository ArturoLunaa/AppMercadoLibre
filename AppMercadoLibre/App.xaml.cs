using AppMercadoLibre.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMercadoLibre
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage nav = new NavigationPage(new ProductsListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["BarBackgroundColor"];
            nav.BarTextColor = (Color)App.Current.Resources["BarTextColor"];

            NavigationPage start = new NavigationPage(new WelcomePage());
            start.BackgroundColor = (Color)App.Current.Resources["BackgroundColor"];
            start.BarBackgroundColor = (Color)App.Current.Resources["BarBackgroundColor"];
            MainPage = start;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
