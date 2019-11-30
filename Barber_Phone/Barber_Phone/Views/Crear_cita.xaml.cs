using Barber_Phone.Clases;
using Barber_Phone.Datos;
using BarberPhoneRD.Datos;
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
    public partial class Crear_Cita : ContentPage
    {
        Cliente cliente = new Cliente();

        public Crear_Cita(Cliente aux)
        {
            InitializeComponent();

            cliente = aux;

            btncrear_cita.IsEnabled = false;

            dpkFecha.MinimumDate = DateTime.Now;
            dpkFecha.MaximumDate = DateTime.Now.AddDays(6);


            CargarPkSector();
        }

        /// <summary>
        /// 
        /// </summary>
        private async void CargarPkSector()
        {
            btncrear_cita.IsEnabled = false;

            try
            {
                /*Obtenemos los datos de los sector disponibles y lo almacenamos en un array*/
                DDireccionB dDireccionB = new DDireccionB();
                var res = await dDireccionB.GetDireccionBSector();

                var direccionB = new List<string>();
                foreach (var item in res)
                {
                    direccionB.Add(item.Sector);
                }

                pkSector.ItemsSource = direccionB;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sector"></param>
        private async void CargarPkBarberias(string sector)
        {
            btncrear_cita.IsEnabled = false;

            try
            {
                /*Obtenemos los datos de los sector disponibles y lo almacenamos en un array*/
                DBarberia dBarberia = new DBarberia();
                var res = await dBarberia.GetBarberia(sector);

                var barberia = new List<string>();
                foreach (var item in res)
                {
                    barberia.Add(item.Nombre);
                }

                pkBarberias.ItemsSource = barberia;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void CargarPkServicios()
        {
            btncrear_cita.IsEnabled = false;

            try
            {
                /*Obtenemos los datos de los sector disponibles y lo almacenamos en un array*/
                DTipo_Servicio dTipo_Servicio = new DTipo_Servicio();
                var res = await dTipo_Servicio.GetTipoServicio();

                var Tipo_Servicio = new List<string>();
                foreach (var item in res)
                {
                    Tipo_Servicio.Add(item.Nombre);
                }

                pkServicios.ItemsSource = Tipo_Servicio;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void CargarPkHora()
        {
            btncrear_cita.IsEnabled = false;

            try
            {
                /*Obtenemos los datos de los sector disponibles y lo almacenamos en un array*/
                DHora_Servicio dHora_Servicio = new DHora_Servicio();
                var res = await dHora_Servicio.GetHoraServicio();

                var Hora_Servicio = new List<string>();
                foreach (var item in res)
                {
                    Hora_Servicio.Add(item.Hora);
                }

                pkHora.ItemsSource = Hora_Servicio;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnDisplayAlertButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Aviso", "Cita creada satisfactoriamente ", "OK");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pkSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            btncrear_cita.IsEnabled = false;
            CargarPkBarberias(pkSector.SelectedItem.ToString());
            pkServicios.ItemsSource = new List<string>();
            pkHora.ItemsSource = new List<string>();
        }

        

        private void pkBarberias_SelectedIndexChanged(object sender, EventArgs e)
        {
            btncrear_cita.IsEnabled = false;
            CargarPkServicios();
            CargarPkHora();
        }

       

        private void dpkFecha_DateSelected(object sender, DateChangedEventArgs e)
        {
            btncrear_cita.IsEnabled = false;
            pkHora.ItemsSource = new List<string>();
            CargarPkHora();

        }

        private void pkHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            btncrear_cita.IsEnabled = true;
        }

        private async void btncrear_cita_Clicked(object sender, EventArgs e)
        {
        
            var fecha = Convert.ToDateTime(dpkFecha.Date).ToString("yy/MM/dd");

            try
            {
                /*Obtenemos los datos del webservices en base al correo del cliente logeado
              y lo almacenamos en un array*/
                DCita dCita = new DCita();
                var res = await dCita.GetCitaCliente(cliente.Correo);

                /*Verifica si hay 1 objetos en el array res y de ser asi muestra una alerta en
                      pantalla cita no disponible*/
                if (res.Count() != 0)
                {
                    await DisplayAlert("Mensaje", "Tiene una cita creada", "Aceptar");
                    await Navigation.PushAsync(new MenuCliente(cliente));
                    return;
                }

                     DCita dcita = new DCita();
                    var res2 = await dcita.PostCita(pkSector.SelectedItem.ToString(),
                        pkBarberias.SelectedItem.ToString(),
                        pkServicios.SelectedItem.ToString(),
                        fecha,
                        pkHora.SelectedItem.ToString(),
                        cliente.Id_Cliente.ToString()); ;

                    await DisplayAlert("Aviso", "Solicitud enviada", "Aceptar");

                    await Navigation.PushAsync(new MenuCliente(cliente));
                
    
            }
            catch (Exception)
            {

                throw;
            }

        }

        
    }  

}