using Barber_Phone.Clases;
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
    public partial class ActualizarPerfilCliente : ContentPage
    {
        Cliente up
        public ActualizarPerfilCliente(Cliente cliente)
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {

        }
    }
}