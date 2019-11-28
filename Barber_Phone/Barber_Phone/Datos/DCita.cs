using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Barber_Phone.Clases;
using System.Linq;
using System.Threading.Tasks;

namespace Barber_Phone.Datos
{
    class DCita
    {
        /// <summary>
        /// Metodo para crear el objeto httpclient y asignar headers.
        /// </summary>
        /// <returns></returns>
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }

        /// <summary>
        /// Metodo para obtener los datos de las citas(Completadas), relacionados con el correo del cliente que esta. 
        /// logeado en la apliacion.
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Cita>> GetHistorialCitaCliente(string correo)
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/GetCitas/GetHistorialCliente.php";
            /*Consumimos el webservices alojado en la URL y obtenemos un array con los datos del usuario en base al 
            correo recibido por parametro*/
            var res = await client.GetAsync(URL + "?correo=" + correo + "");

            /*Evaluamos la respuesta HTTP recibida en res fue satisfactoria*/
            if (res.IsSuccessStatusCode)
            {
                //Recibimos el contenido de res y lo almacenamos en un string
                string content = await res.Content.ReadAsStringAsync();

                /*Convertimos el contenido del Json a un array de objetos de tipo Cita y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<Cita>>(content);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Cita>();
        }
    }
}
