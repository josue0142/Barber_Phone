using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Barber_Phone.Datos;
using System.Collections;
using Barber_Phone.Clases;

namespace Barber_Phone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();

            //Cargamos las opciones para el picker de tipo de usuario que ingresara a la app.
            pkTipoLogin.Items.Add("Cliente");
            pkTipoLogin.Items.Add("Barbero");

        }

        /// <summary>
        /// Metodo utilizado cuando se presiona 1 vez el btnIngresar. Ejecuta las instrucciones para
        /// la validacion de usuarios y el ingreso a la aplicacion. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {

            #region Evaluar que los campos de correo y contraseña no esten vacios
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
            #endregion

            ActivarDesactivarActivityIndicator(true);

            try
            {
                //Evaluamos si el tipo de login seleccionado es cliente.
                if (pkTipoLogin.SelectedIndex == 0)
                {
                    /*Obtenemos los datos del webservices en base al correo ingresado en el textbox
                    y lo almacenamos en un array*/
                    DCliente dCliente = new DCliente();
                    var res = await dCliente.GetExisteCliente(txtCorreo.Text);

                    /*Verifica si hay 0 objetos en el array res y de ser asi muestra una alerta en
                   pantalla de usuario no registrado*/
                    if (res.Count() == 0)
                    {
                        ActivarDesactivarActivityIndicator(false);
                        await DisplayAlert("Error", "Este correo no esta registrado", "Aceptar");
                        txtCorreo.Text = "";
                        txtContraseña.Text = "";
                        txtCorreo.Focus();
                        return;
                    }

                    /*Evaluamos el array res para verificar si la contraseña coincide con la ingresada
                     en el textbox*/
                    foreach (var item in res)
                    {
                        if (item.Contraseña == txtContraseña.Text)
                        {
                            goToMenuCliente(item);
                            //enviamos el objeto cliente (item) para se utilziado en la carga de datos
                            //posteriores en la interfaz, algo parecido a crear una sesion. 
                        }
                        else
                        {
                            ActivarDesactivarActivityIndicator(false);
                            await DisplayAlert("Error", "Contraseña incorrecta", "Aceptar");
                            txtContraseña.Text = "";
                            txtContraseña.Focus();
                            return;
                        }
                    }

                }//Evaluamos si el tipo de login seleccionado es barbero.                
                else if (pkTipoLogin.SelectedIndex == 1)
                {
                    /*Obtenemos los datos del webservices en base al correo ingresado en el textbox
                    y lo almacenamos en un array*/
                    DBarbero dBarbero = new DBarbero();
                    var res = await dBarbero.GetExisteBarbero(txtCorreo.Text);

                    /*Verifica si hay 0 objetos en el array res y de ser asi muestra una alerta en
                    pantalla de usuario no registrado*/
                    if (res.Count() == 0)
                    {
                        ActivarDesactivarActivityIndicator(false);
                        await DisplayAlert("Error", "Este correo no esta registrado", "Aceptar");
                        txtCorreo.Text = "";
                        txtContraseña.Text = "";
                        txtCorreo.Focus();
                        return;
                    }

                    /*Evaluamos el array res para verificar si la contraseña coincide con la ingresada
                    en el textbox*/
                    foreach (var item in res)
                    {
                        if (item.Contraseña == txtContraseña.Text)
                        {
                            goToMenuBarbero(item);
                            //enviamos el objeto barbero (item) para se utilziado en la carga de datos
                            //posteriores en la interfaz, algo parecido a crear una sesion. 
                        }
                        else
                        {
                            ActivarDesactivarActivityIndicator(false);
                            await DisplayAlert("Error", "Contraseña incorrecta", "Aceptar");
                            txtContraseña.Text = "";
                            txtContraseña.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    ActivarDesactivarActivityIndicator(false);
                    await DisplayAlert("Error", "Debe seleccionar el tipo de usuario", "Aceptar");
                    //pkTipoLogin.Focus();
                    return;
                }

            }
            catch (Exception)
            {
                ActivarDesactivarActivityIndicator(false);
                throw;
            }

            ActivarDesactivarActivityIndicator(false);

        }

        /// <summary>
        /// Metodo para activar/desactivar el indicador de actividad y los botones en la pantalla de login. 
        /// </summary>
        /// <param name="aux"></param>
        private void ActivarDesactivarActivityIndicator(bool aux)
        {
            if (aux)
            {
                waitActivityIndicator.IsRunning = true;
                btnIngresar.IsEnabled = false;
                btnRegistrar.IsEnabled = false;
            }
            else
            {
                btnRegistrar.IsEnabled = true;
                btnIngresar.IsEnabled = true;
                waitActivityIndicator.IsRunning = false;
            }
        }

        /// <summary>
        /// Metodo utilizado cuando se presiona 1 vez el btnIngresar. Ejecuta las instrucciones para
        /// ir a la pagina de tipoRegistro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new tipoRegistro());
        }

        /// <summary>
        /// Metodo para acceder a la interfaz de Barbero.
        ///Enviamos un objeto cliente para crear la sesion durante la utilizacion de la
        /// aplicacion por parte del usuario 
        /// </summary>
        private void goToMenuBarbero(Barbero  barbero)
        {
            Navigation.PushAsync(new MenuBarbero(barbero));
        }

        /// <summary>
        /// Metodo para acceder a la interfaz de cliente.
        /// Enviamos un objeto cliente para crear la sesion durante la utilizacion de la
        /// aplicacion por parte del usuario 
        /// </summary>
        private void goToMenuCliente(Cliente cliente)
        {
            Navigation.PushAsync(new MenuCliente(cliente));
        }
    }
}