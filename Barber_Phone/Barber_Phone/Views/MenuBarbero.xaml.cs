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
    public partial class MenuBarbero : MasterDetailPage
    {
        public MenuBarbero()
        {
            InitializeComponent();

            //Definimos nuestra pantalla Master
            Master = new opcionesMenuBarbero();
            //Definimos nuestra pantalla Detail
            Detail = new NavigationPage(new inicioBarbero());

            App.Modificador = this;
        }
    }
}