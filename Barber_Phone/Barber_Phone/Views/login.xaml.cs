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
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();

            //Carga de opciones para el picker
            pkTipoLogin.Items.Add("Cliente");
            pkTipoLogin.Items.Add("Barbero");
        }

        //Metodo para un clic del btn ingresa, No programado, En fase de prueba
        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            lblRespuesta.Text = "Bienvenido Nuevo " + pkTipoLogin.SelectedItem;
            txtCorreo.Text = "";
            txtContraseña.Text = "";
        }
    }
}