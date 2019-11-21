using Barber_Phone.Clases;
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
    public partial class opcionesMenuCliente : ContentPage
    {
        public opcionesMenuCliente(Cliente cliente)
        {
            InitializeComponent();

            /*Item1.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new verAgendaBarbero());
                App.Modificador.IsPresented = false;
            };*/
            Item2.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new Crear_Cita(cliente));
                App.Modificador.IsPresented = false;
            };
            /*Item3.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new PantallaItemTres());
                App.Modificador.IsPresented = false;
            };*/
            Item4.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new HistorialCliente(cliente));
                App.Modificador.IsPresented = false;
            };
            /*Item5.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new login());
                App.Modificador.IsPresented = false;
            };*/
            Item6.Clicked += async (sender, e) =>
            {
                await App.Modificador.Detail.Navigation.PushAsync(new login());
                App.Modificador.IsPresented = false;
            };
        }

        /// <summary>
        /// Bloqueamos/Desbloqueamos el boton fisico de retroceso. 
        /// True Bloqueado, False Desbloqueado
        /// </summary>
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}