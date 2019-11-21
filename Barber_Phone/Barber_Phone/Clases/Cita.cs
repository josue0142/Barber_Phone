using System;
using System.Collections.Generic;
using System.Text;

namespace Barber_Phone.Clases
{
    class Cita
    {
        private string cliente;
        private string barbero;
        private string barberia;
        private string hora;
        private string fecha;
        private string servicio;
        private string duracion;
        private string estado;

        public string Cliente { get => cliente; set => cliente = value; }
        public string Barbero { get => barbero; set => barbero = value; }
        public string Barberia { get => barberia; set => barberia = value; }
        public string Hora { get => hora; set => hora = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Servicio { get => servicio; set => servicio = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public string Estado { get => estado; set => estado = value; }
        
    }
}
