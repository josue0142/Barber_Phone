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
    public partial class PerfilBarbero : ContentPage
    {
        public PerfilBarbero()
        {
            InitializeComponent();
        }
        private async void btnActualizarDatosB_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActulizarPefilBarbero());
        }
    }

}