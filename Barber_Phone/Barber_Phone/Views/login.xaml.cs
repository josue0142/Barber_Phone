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
        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCorreo.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un correo", "Aceptar");
                txtCorreo.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una contraseña", "Aceptar");
                txtContraseña.Focus();
                return;
            }


            
            if (pkTipoLogin.SelectedItem.ToString() == "Cliente")
            {
                lblRespuesta.Text = "Bienvenido " + "Cliente";
            }
            if(pkTipoLogin.SelectedItem.ToString() == "Barbero")
            {
                lblRespuesta.Text = "Bienvenido  " + "Barbero";
            }
            /*else
            {
                lblRespuesta.Text = "error, debe seleccionar un tipo de usuario";
            }*/
            /*
            lblRespuesta.Text = "Bienvenido Nuevo " + pkTipoLogin.SelectedItem;
            txtCorreo.Text = "";
            txtContraseña.Text = "";*/
        }
    }
}