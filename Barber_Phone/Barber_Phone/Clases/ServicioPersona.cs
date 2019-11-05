using System;
using System.Collections.Generic;
using System.Text;

namespace Barber_Phone.Clases
{
    public class ServicioPersona
    {

        public List<Persona> ConsultarPersona()
        {
            var lista = new List<Persona>();

            lista.Add(new Persona() { Nombre = "Jefferson", apellido = "Villanueva", hora = "10:15 AM" });
            lista.Add(new Persona() { Nombre = "Josue", apellido = "Jimenez", hora = "11:15 AM" });
            lista.Add(new Persona() { Nombre = "Benjamin", apellido = "Guchi", hora = "10:45 AM" });
            return lista;
        }






    }
}
