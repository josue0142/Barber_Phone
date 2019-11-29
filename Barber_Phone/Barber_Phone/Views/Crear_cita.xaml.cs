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
        private void CargarPkSector()
        {
            try
            {
                /*Obtenemos los datos de los sector disponibles y lo almacenamos en un array*/
                DDireccionB dDireccionB = new DDireccionB();
                var res = dDireccionB.GetDireccionB().Result;

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

        private async void OnDisplayAlertButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Aviso", "Cita creada satisfactoriamente ", "OK");

        }

    }  

}