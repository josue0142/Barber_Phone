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
    class DHora_Servicio
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
        /// Metodo para obtener los horas disponibles para el servicio que se va a realizar.  
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Hora_Servicio>> GetHoraServicio()
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/PostCitas/GetHora.php";
            /*Consumimos el webservices alojado en la URL y obtenemos un array con los datos de las horas*/
            var res = await client.GetAsync(URL);

            /*Evaluamos la respuesta HTTP recibida en res fue satisfactoria*/
            if (res.IsSuccessStatusCode)
            {
                //Recibimos el contenido de res y lo almacenamos en un string
                string content = await res.Content.ReadAsStringAsync();

                /*Convertimos el contenido del Json a un array de objetos de tipo Hora_Servicio y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<Hora_Servicio>>(content);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Hora_Servicio>();
        }
    }
}
