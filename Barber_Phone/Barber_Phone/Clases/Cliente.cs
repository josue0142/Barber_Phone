using System;
using System.Collections.Generic;
using System.Text;

namespace Barber_Phone.Clases
{
    public class Cliente
    {
        private int id_Cliente;
        private string primer_Nombre;
        private string primer_Apellido;
        private string correo;
        private string contraseña;
        private string numero_Telefono;

        public int Id_Cliente { get => id_Cliente; set => id_Cliente = value; }
        public string Primer_Nombre { get => primer_Nombre; set => primer_Nombre = value; }
        public string Primer_Apellido { get => primer_Apellido; set => primer_Apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Numero_Telefono { get => numero_Telefono; set => numero_Telefono = value; }

    }
}
