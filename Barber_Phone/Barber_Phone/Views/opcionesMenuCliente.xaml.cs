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
        public opcionesMenuCliente()
        {
            InitializeComponent();

        }
        private async void TapGestureRecognizer_Tapped0(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistorialCliente());
        }
        private async void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Crear_Cita());
        }
        private async void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Configuracion());
        }
      
    }
}