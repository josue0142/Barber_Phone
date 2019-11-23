using Barber_Phone.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Barber_Phone
{
    public partial class App : Application
    {
        public static MasterDetailPage Modificador { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new login());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
