using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Barber_Phone.Datos;

namespace Barber_Phone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();

            //Inicio. Carga de opciones para el picker de tipo de usuario a logear
            pkTipoLogin.Items.Add("Cliente");
            pkTipoLogin.Items.Add("Barbero");
            //Fin

            //Inicio. Establece campo de contraseña con caracteres ocultos
            txtContraseña.IsPassword = true;
            //Fin
        }

        //Inicio. Evento para el click del boton ingresar
        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {

            //Inicio. Evalua que los campos de correo y contraseña no esten vacios
            if (string.IsNullOrEmpty(txtCorreo.Text))
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
            //Fin. Evalua que los campos de correo y contraseña no esten vacios


            
            try
            {
                DCliente dCliente = new DCliente();
                var res = await dCliente.GetClientes();//Obtiene datos de clientes desde la clase DCliente

                /*Inicio. Verifica datos de acceso obtenidos desde el usuario*/
                foreach (var item in res)
                {                 
                    if (item.Correo == txtCorreo.Text)
                    {
                        if (item.Contraseña == txtContraseña.Text)
                        {
                            lblRespuesta.Text = "Datos coinciden";                           
                        }
                        else
                        {
                            await DisplayAlert("Error", "Contraseña incorrecta", "Aceptar");
                            txtContraseña.Text = "";
                            txtContraseña.Focus();
                            return;
                        }
                    }
                }

                //Este ventana emergente hay que trabajarle, ya que no se debe activar cuando
                //los datos del usuarios sean correctos
                await DisplayAlert("Error", "Este correo no esta registrado", "Aceptar");
                txtCorreo.Text = "";
                txtContraseña.Text = "";
                txtCorreo.Focus();
                /*Fin. Verifica datos de acceso obtenidos desde el usuario*/

            }
            catch (Exception e1)
            {
                throw;
            }
            
           /* if (pkTipoLogin.SelectedItem.ToString() == "Cliente")
            {
                lblRespuesta.Text = "Bienvenido " + "Cliente";
            }
            if(pkTipoLogin.SelectedItem.ToString() == "Barbero")
            {
                lblRespuesta.Text = "Bienvenido  " + "Barbero";
            }*/
            /*else
            {
                lblRespuesta.Text = "error, debe seleccionar un tipo de usuario";
            }*/
            /*
            lblRespuesta.Text = "Bienvenido Nuevo " + pkTipoLogin.SelectedItem;
            txtCorreo.Text = "";
            txtContraseña.Text = "";*/

        }
        //Fin. Evento para el click del boton ingresar
    }
}