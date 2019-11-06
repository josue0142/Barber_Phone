using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Barber_Phone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class verAgendaBarbero : ContentPage
    {
        public verAgendaBarbero()
        {
            InitializeComponent();


            MainListView.ItemsSource = new List<Cita>
            {
                new Cita
                {

                    Cliente = "Cliente: Josue Jimenez",
                    Servicio = "Tipo de servicio: Cerquillo",
                    Hora = "Hora: 10:25",
                    Fecha = "Fecha: 06/11/2019",
                    Duracion = "Duracion: 15 minutos"
                },

                new Cita
                {
                    Cliente = "Cliente: Benjamin",
                    Servicio = "Tipo de servicio: Cerquillo",
                    Hora = "10:25",
                    Fecha = "06/11/2019",
                    Duracion = "15 minutos"

                }



            };
        }

    }
}