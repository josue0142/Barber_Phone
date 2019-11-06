using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Barber_Phone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class opcionesMenuBarbero : ContentPage
    {
        public opcionesMenuBarbero()
        {
            InitializeComponent();

            Item1.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new verAgendaBarbero());
                App.Modificador.IsPresented = false;
            };
            /*Item2.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new PantallaItemDos());
                App.Modificador.IsPresented = false;
            };
            Item3.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new PantallaItemTres());
                App.Modificador.IsPresented = false;
            };*/
            Item4.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new login());
                App.Modificador.IsPresented = false;
            };

        }
    }
}