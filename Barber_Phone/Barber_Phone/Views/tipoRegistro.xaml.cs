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
    public partial class tipoRegistro : ContentPage
    {
        public tipoRegistro()
        {
            InitializeComponent();
        }

        private async void btnRegistroc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registroc());
        }

        private async void btnRegistrarb_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registrob());
        }
    }
}