using Barber_Phone.Datos;
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
    public partial class registroc : ContentPage
    {
        public registroc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo utilizado cuando se presiona 1 vez el btnRegistrar. Ejecuta las instrucciones para
        /// validar los datos ingresados en el formulario de registro 
        /// y registra a los clientes en la aplicacion(Base de datos).  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {

            #region Evaluar que los campos de registro no esten vacios
            if (string.IsNullOrEmpty(txtnombrerb.Text) || string.IsNullOrEmpty(txtapellidob.Text) ||
                string.IsNullOrEmpty(txtcorreob.Text) || string.IsNullOrEmpty(txtcontraseñab.Text) ||
                string.IsNullOrEmpty(txtcontraseñaconfb.Text) || string.IsNullOrEmpty(txttelefono.Text))    
            {
                await DisplayAlert("Error", "Faltan campos por completar", "Aceptar");               
                return;
            }
            #endregion

            ActivarDesactivarActivityIndicator(true);

            try
            {

                #region Validar correo
                /*Obtenemos los datos del webservices en base al correo ingresado en el textbox
                  y lo almacenamos en un array*/
                DCliente dCliente = new DCliente();
                var res = await dCliente.GetExisteCliente(txtcorreob.Text);

                /*Verifica si hay objetos en el array res y de ser asi muestra una alerta en
                 pantalla de usuario ya registrado*/
                if (res.Count() != 0)
                {
                    ActivarDesactivarActivityIndicator(false);
                    await DisplayAlert("Error", "Este correo esta registrado", "Aceptar");
                    txtcorreob.Text = "";
                    txtcorreob.Focus();
                    return;
                }
                #endregion

                #region Validar contraseña
                //Validamos si los campos de contraseña y confirmacion de contraseña son iguales
                if (txtcontraseñab.Text != txtcontraseñaconfb.Text)
                {
                    ActivarDesactivarActivityIndicator(false);
                    await DisplayAlert("Error", "Contraseñas no coinciden", "Aceptar");
                    txtcontraseñab.Text = "";
                    txtcontraseñaconfb.Text = "";
                    txtcontraseñab.Focus();
                    return;
                }
                #endregion

                
                #region Enviar a la BD datos del Cliente
                /*Creamos un objeto de la clase Cliente y almacenamos los valores de los campos
                del formulario en los atributos del objeto.*/
                Cliente cliente = new Cliente();

                cliente.Primer_Nombre = txtnombrerb.Text;
                cliente.Primer_Apellido = txtapellidob.Text;
                cliente.Correo = txtcorreob.Text;
                cliente.Contraseña = txtcontraseñab.Text;
                cliente.Numero_Telefono = txttelefono.Text;

                var res2 = await dCliente.PostCliente(cliente);

                /*Verifica si hay 0 objetos en el array res2 y de ser asi muestra una alerta en
                 pantalla error por que el usuario no fue registrado*/
                if (res2.Count() == 0)
                {
                    ActivarDesactivarActivityIndicator(false);
                    await DisplayAlert("Error", "Ops! Algo Fallo", "Aceptar");
                    goToLogin();
                    return;
                }


                /*Evaluamos el array res2 para verificar si el correo  coincide con el ingresada
                 en el textbox y confirmamos que el registro fue realizado*/
                foreach (var item in res2)
                {
                    if(item.Correo == txtcorreob.Text)
                    {
                        ActivarDesactivarActivityIndicator(false);
                        await DisplayAlert("Exito", "Registro realizado con exito", "Aceptar");
                        goToLogin();
                        return;
                    }
                }
                #endregion

            }
            catch (Exception)
            {
                ActivarDesactivarActivityIndicator(false);
                throw;
            }

        }

        /// <summary>
        /// Metodo para activar/desactivar el indicador de actividad, los botones en la pantalla y los campos
        /// del formulario.
        /// true = activar, false = desactivar
        /// </summary>
        /// <param name="aux"></param>
        private void ActivarDesactivarActivityIndicator(bool aux)
        {
            if (aux)
            {
                waitActivityIndicator.IsRunning = true;
                btnRegistrar.IsEnabled = false;
                txtnombrerb.IsEnabled = false;
                txtapellidob.IsEnabled = false;
                txtcorreob.IsEnabled = false;
                txtcontraseñab.IsEnabled = false;
                txtcontraseñaconfb.IsEnabled = false;
                txttelefono.IsEnabled = false;
            }
            else
            {
                txtnombrerb.IsEnabled = true;
                txtapellidob.IsEnabled = true;
                txtcorreob.IsEnabled = true;
                txtcontraseñab.IsEnabled = true;
                txtcontraseñaconfb.IsEnabled = true;
                txttelefono.IsEnabled = true;
                btnRegistrar.IsEnabled = true;
                waitActivityIndicator.IsRunning = false;
            }
        }

        /// <summary>
        /// Devuelve al usuario a la pantalla de login
        /// </summary>
        private void goToLogin()
        {
            Navigation.PushAsync(new login());
        }
    }
}