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
    public partial class MenuCliente : MasterDetailPage
    {
        public MenuCliente()
        {
            InitializeComponent();

            //Definimos nuestra pantalla Master
            Master = new opcionesMenuCliente();
            //Definimos nuestra pantalla Detail
            Detail = new NavigationPage(new inicioCliente());

            App.Modificador = this;
        }
    }
}