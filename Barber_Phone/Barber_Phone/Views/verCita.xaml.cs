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
    public partial class verCita : ContentPage
    {
        Cliente delCliente = new Cliente();
        public verCita(Cliente cliente)
        {
            InitializeComponent();
            delCliente = cliente;
            VerCita(cliente);
        }

        /// <summary>
        /// Metodo para mostrar la cita al cliente. 
        /// </summary>
        /// <param name="cliente"></param>
        private async void VerCita(Cliente cliente)
        {
            try
            {
                /*Obtenemos los datos del webservices en base al correo del cliente logeado
            y lo almacenamos en un array*/
                DCita dCita = new DCita();
                var res = await dCita.GetCitaCliente(cliente.Correo);

                /*Verifica si hay 0 objetos en el array res y de ser asi muestra una alerta en
                      pantalla cita no disponible*/
                if (res.Count() == 0)
                {
                    await DisplayAlert("Mensaje", "Cita no disponible", "Aceptar");
                    return;
                }

                //Creamos una lista para cargarla con los datos del array res
                var cita = new List<Cita>();
                foreach (var item in res)
                {
                    cita.Add(new Cita
                    {
                        Barbero = "Barbero: " + item.Barbero,
                        Barberia = "Barberia: " + item.Barberia,
                        Servicio = "Tipo de servicio: " + item.Servicio,
                        Hora = "Hora: " + item.Hora,
                        Fecha = "Fecha: " + item.Fecha,
                        Duracion = "Duracion: " + item.Duracion
                    });
                }

                //Establecemos la variable cita como la fuente de datos para
                //el listview de la pantalla verCita
                MainListView.ItemsSource = cita;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void btneliminar_Cita_Clicked(object sender, EventArgs e)
        {
            try
            {
                /*Obtenemos los datos del webservices en base al correo del cliente logeado
            y lo almacenamos en un array*/
                DCita dCita = new DCita();
                var res = await dCita.GetCitaCliente(delCliente.Correo);

                
                foreach (var item in res)
                {
                    dCita.EliminarCita(item.Id_Cita);
                    await DisplayAlert("Proceso", "Cita eliminada", "Aceptar");
                }

                await Navigation.PushAsync(new MenuCliente(delCliente));


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}