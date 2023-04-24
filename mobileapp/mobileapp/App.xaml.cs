using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileapp
{
    public partial class App : Application
    {
        public static string Databaselocatin = string.Empty;
        public App()
        {
            InitializeComponent();
            

            MainPage = new NavigationPage(new MainPage());
            
        }
        public App(string databaselocation)
        {
            InitializeComponent();


            MainPage = new NavigationPage(new MainPage());
            Databaselocatin = databaselocation;
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
