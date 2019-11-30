using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarberPhoneRD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarCita : ContentPage
    {
        public EditarCita()
        {
            InitializeComponent();
        }


        private async void btneditarcita(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarDatosCita ());
        }


    }
}