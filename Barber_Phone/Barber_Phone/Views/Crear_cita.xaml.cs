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
        public Crear_Cita(Cliente cliente)
        {
            InitializeComponent();

            CargarPkSector();
        }

        /// <summary>
        /// 
        /// </summary>
        private async void CargarPkSector()
        {
            try
            {
                /*Obtenemos los datos de los sector disponibles y lo almacenamos en un array*/
                DDireccionB dDireccionB = new DDireccionB();
                var res = await dDireccionB.GetDireccionB();

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
            CargarPkBarberias(pkSector.SelectedItem.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sector"></param>
        private async void CargarPkBarberias(string sector)
        {
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

        private void pkBarberias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPkServicios();
        }

        private async void CargarPkServicios()
        {
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
    }  

}