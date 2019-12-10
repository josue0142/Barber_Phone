using BarberPhoneRD.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BarberPhoneRD.Datos
{
    class DBarberia
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
        /// Metodo para obtener los datos de las barberias. 
        /// utiliza el sector como parametro de busqueda   
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Barberia>> GetBarberia(string sector)
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/PostCitas/GetBarberia.php";
            /*Consumimos el webservices alojado en la URL y obtenemos un array con los datos de las barberias en 
             * base al sector enviado como parametro*/
            var res = await client.GetAsync(URL + "?sector=" + sector + " ");

            /*Evaluamos la respuesta HTTP recibida en res fue satisfactoria*/
            if (res.IsSuccessStatusCode)
            {
                //Recibimos el contenido de res y lo almacenamos en un string
                string content = await res.Content.ReadAsStringAsync();

                /*Convertimos el contenido del Json a un array de objetos de tipo barberia y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<Barberia>>(content);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Barberia>();
        }

    }
}
