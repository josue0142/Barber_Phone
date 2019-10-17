using System;
using System.Collections.Generic;
using System.Text;

namespace Barber_Phone.Clases
{
    class Barbero
    {
        private string nombre;
        private string apellido;
        private string correo;
        private string contraseña;
        private string telefono;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
