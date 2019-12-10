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
    public partial class PerfilBarbero : ContentPage
    {
        Barbero upBarbero = new Barbero();

        public PerfilBarbero(Barbero barbero)
        {
            InitializeComponent();

            #region Carga de datos a los campos del perfil
            lblNombre.Text = barbero.Primer_Nombre;
            lblApellido.Text = barbero.Primer_Apellido;
            lblTelefono.Text = barbero.Numero_Telefono;
            lblCorreo.Text = barbero.Correo;
            upBarbero = barbero;
            //lblBarberiaA.Text = barbero.Barberia;
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
            await Navigation.PushAsync(new ActulizarPefilBarbero(upBarbero));
        }
    }

}