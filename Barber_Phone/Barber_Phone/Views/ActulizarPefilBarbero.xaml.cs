using Barber_Phone.Clases;
using Barber_Phone.Datos;
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
    public partial class ActulizarPefilBarbero : ContentPage
    {
        Barbero upBarbero = new Barbero();

        public ActulizarPefilBarbero(Barbero barbero)
        {
            InitializeComponent();

            upBarbero = barbero;
        }

        /// <summary>
        /// Metodo utilizado cuando se presiona 1 vez el btnGuardar. Ejecuta las instrucciones
        /// para actualizar los datos del usuario en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                #region Validar contraseña
                //Validamos si los campos de contraseña y confirmacion de contraseña son iguales
                if (txtContraseña.Text != txtConfContraseña.Text)
                {
                    await DisplayAlert("Error", "Contraseñas no coinciden", "Aceptar");
                    return;
                }
                #endregion

                #region Enviar datos a la BD
                upBarbero.Contraseña = txtContraseña.Text;
                upBarbero.Numero_Telefono = txtTelefono.Text;

                DBarbero dBarbero = new DBarbero();
                var res = await dBarbero.UpdateBarbero(upBarbero);

                #endregion

                await DisplayAlert("Proceso", "Procesando los cambios", "Aceptar");

                await Navigation.PushAsync(new PerfilBarbero(upBarbero));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}