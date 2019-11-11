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
    public partial class HistorialCliente : ContentPage
    {
        public HistorialCliente()
        {
            InitializeComponent();


            HistorialListView.ItemsSource = new List<Historial>
            {
                new Historial
                {

                    Cliente = "Cliente: Josue Jimenez",
                    Servicio = "Tipo de servicio: Cerquillo",
                    Hora = "Hora: 10:25",
                    Fecha = "Fecha: 06/11/2019",
                    Duracion = "Duracion: 15 minutos"
                },

                new Historial
                {
                    Cliente = "Cliente: Benjamin Libert",
                    Servicio = "Tipo de servicio: Cerquillo y Barba",
                    Hora = "10:40",
                    Fecha = "06/11/2019",
                    Duracion = "25 minutos"

                },
                 new Historial
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