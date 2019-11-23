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
    public partial class Crear_Cita : ContentPage
    {
        public Crear_Cita(Cliente cliente)
        {
            InitializeComponent();


            }

         async void OnDisplayAlertButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Aviso", "Cita creada satisfactoriamente ", "OK");

        }
    }
}