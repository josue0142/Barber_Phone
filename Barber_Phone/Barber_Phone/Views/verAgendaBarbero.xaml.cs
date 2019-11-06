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
            ObservableCollection<Cliente> listaPersona = new ObservableCollection<Cliente>(new ServicioPersona().ConsultarPersona());
            lstPersonas.ItemsSource = listaPersonas;
        }
    }
}