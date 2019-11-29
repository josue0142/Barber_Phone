using System;
using System.Collections.Generic;
using System.Text;

namespace Barber_Phone.Clases
{
    class DireccionB
    {
        private string calle;
        private int no_Casa;
        private string sector;
        private string provincia;

        public string Calle { get => calle; set => calle = value; }
        public int No_Casa { get => no_Casa; set => no_Casa = value; }
        public string Sector { get => sector; set => sector = value; }
        public string Provincia { get => provincia; set => provincia = value; }
    }
}
