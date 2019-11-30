using Barber_Phone.Clases;
using Barber_Phone.Datos;
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

        Cliente upcliente = new Cliente();

        public ActualizarPerfilCliente(Cliente cliente)
        {
            InitializeComponent();

            txtTelefono.Text = cliente.Numero_Telefono;
            txtContraseña.Text = cliente.Contraseña;
            txtConfContraseña.Text = cliente.Contraseña;
            upcliente = cliente;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                #region Validar contraseña
                //Validamos si los campos de contraseña y confirmacion de contraseña son iguales
                if (txtContraseña.Text != txtConfContraseña.Text)
                {
                    //ActivarDesactivarActivityIndicator(false);
                    await DisplayAlert("Error", "Contraseñas no coinciden", "Aceptar");
                    return;
                }
                #endregion

                #region Enviar datos a la BD
                upcliente.Contraseña = txtContraseña.Text;
                upcliente.Numero_Telefono = txtTelefono.Text;

                DCliente dCliente = new DCliente();
                var res = await dCliente.UpdateCliente(upcliente);

                #endregion
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}