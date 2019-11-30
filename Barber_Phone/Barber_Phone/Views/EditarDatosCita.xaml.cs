using Barber_Phone.Clases;
using Barber_Phone.Views;
using BarberPhoneRD.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarberPhoneRD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarDatosCita : ContentPage
    {
        Cliente xcliente = new Cliente();
        Cita cita = new Cita();
        public EditarDatosCita(Cita editCita,Cliente cliente)
        {
            InitializeComponent();
            CargarPkServicios();
            btnGuardar.IsEnabled = false;
            xcliente = cliente;
            cita = editCita;
        }

        private async void CargarPkServicios()
        {
            btnGuardar.IsEnabled = false;

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

        private void pkServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGuardar.IsEnabled = true;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                DTipo_Servicio dTipo_Servicio = new DTipo_Servicio();
                var res = await dTipo_Servicio.UpdateTipoServicio(pkServicios.SelectedItem.ToString(),cita);

                await DisplayAlert("Proceso", "Procesando los cambios", "Aceptar");

                await Navigation.PushAsync(new MenuCliente(xcliente));
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}