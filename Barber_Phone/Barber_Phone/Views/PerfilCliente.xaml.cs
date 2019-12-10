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
    public partial class PerfilCliente : ContentPage
    {
        Cliente upcliente = new Cliente();

        public PerfilCliente(Cliente cliente)
        {

            InitializeComponent();

            #region Carga de datos a los campos del perfil
            lblNombre.Text = cliente.Primer_Nombre;
            lblApellido.Text = cliente.Primer_Apellido;
            lblTelefono.Text = cliente.Numero_Telefono;
            lblCorreo.Text = cliente.Correo;
            upcliente = cliente;
            #endregion 

        }

        /// <summary>
        /// Metodo utilizado cuando se presiona 1 vez el btnActualizar. envia al usuario
        /// a la pantalla para actualizar los datos permitidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarPerfilCliente(upcliente));
        }
    }
}