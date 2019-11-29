using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Barber_Phone.Clases;
using Barber_Phone.Datos;

namespace Barber_Phone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorialCliente : ContentPage
    {
        public HistorialCliente(Cliente cliente)
        {
            InitializeComponent();

            MostrarHistorial(cliente);
        }

        /// <summary>
        /// Metodo para mostrar el historial del cliente. 
        /// </summary>
        /// <param name="cliente"></param>
        private async void MostrarHistorial(Cliente cliente)
        {
            try
            {
                /*Obtenemos los datos del webservices en base al correo del cliente logeado
            y lo almacenamos en un array*/
                DCita dCita = new DCita();
                var res = await dCita.GetHistorialCitaCliente(cliente.Correo);

                /*Verifica si hay 0 objetos en el array res y de ser asi muestra una alerta en
                      pantalla historial no disponible*/
                if (res.Count() == 0)
                {
                    await DisplayAlert("Mensaje", "Historial no disponible", "Aceptar");
                    return;
                }

                //Creamos una lista para cargarla con los datos del array res
                var historial = new List<Cita>();
                foreach (var item in res)
                {
                    historial.Add(new Cita
                    {
                        Barbero = "Barbero: "+ item.Barbero,
                        Barberia = "Barberia: "+item.Barberia,  
                        Servicio = "Tipo de servicio: "+item.Servicio,
                        Hora = "Hora: "+item.Hora,
                        Fecha = "Fecha: "+item.Fecha,
                        Duracion = "Duracion: "+item.Duracion
                    });
                }

                //Establecemos la variable historial como la fuente de datos para
                //el listview de la pantalla historial
                HistorialListView.ItemsSource = historial;

            }
            catch (Exception)
            {
                throw;
            } 
        
        }

    }
}