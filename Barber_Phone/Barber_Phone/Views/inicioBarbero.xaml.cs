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
    public partial class inicioBarbero : ContentPage
    {
        public inicioBarbero()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bloqueamos/Desbloqueamos el boton fisico de retroceso. 
        /// True Bloqueado, False Desbloqueado
        /// </summary>
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}