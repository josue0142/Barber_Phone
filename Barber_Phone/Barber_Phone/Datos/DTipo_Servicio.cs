using Barber_Phone.Clases;
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
    class DTipo_Servicio
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
        /// Metodo para obtener los tipos de servicios. 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Tipo_Servicio>> GetTipoServicio()
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/PostCitas/GetTipoServicio.php";
            /*Consumimos el webservices alojado en la URL y obtenemos un array con los datos de los tipos
             de servicio*/
            var res = await client.GetAsync(URL);

            /*Evaluamos la respuesta HTTP recibida en res fue satisfactoria*/
            if (res.IsSuccessStatusCode)
            {
                //Recibimos el contenido de res y lo almacenamos en un string
                string content = await res.Content.ReadAsStringAsync();

                /*Convertimos el contenido del Json a un array de objetos de Tipo_Servicio y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<Tipo_Servicio>>(content);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Tipo_Servicio>();
        }

        /// <summary>
        /// Metodo para enviar los datos del tipo de servicio actualizado a la base de datos.  
        /// </summary>
        /// <param name="tipo_Servicio"></param>
        /// <param name="cita"></param>
        /// <returns></returns>
        public async Task UpdateTipoServicio(string tipo_Servicio,Cita cita)
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/UdateCitas/UpdateTipoServicio.php";

            //Creamos una tupla con los datos del tipo de la cita, el tipo de servicio a actualizar y lo almacenamos en la variable content 
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("tipo_Servicio", tipo_Servicio),
                new KeyValuePair<string, string>("id_Cita", cita.Id_Cita.ToString()),
            }
            );

            /*Consumimos el webservices alojado en la URL, enviamos
             * mediante el metodo PostAsync los datos de la actualizacion del servicio*/
            await client.PostAsync(URL, content);

        }
    }
}
