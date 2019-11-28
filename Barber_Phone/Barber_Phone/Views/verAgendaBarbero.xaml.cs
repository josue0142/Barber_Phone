using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Barber_Phone.Clases;

namespace Barber_Phone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class verAgendaBarbero : ContentPage
    {
        public verAgendaBarbero(Barbero barbero)
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
                    Cliente = "Cliente: Benjamin Libert",
                    Servicio = "Tipo de servicio: Cerquillo y Barba",
                    Hora = "10:40",
                    Fecha = "06/11/2019",
                    Duracion = "25 minutos"

                },
                 new Cita
                {
                    Cliente = "Cliente: Jefferson Villanueva",
                    Servicio = "Tipo de servicio: Corte sencillo",
                    Hora = "11:05",
                    Fecha = "06/11/2019",
                    Duracion = "25 minutos"

                }



            };
        }

    }
}