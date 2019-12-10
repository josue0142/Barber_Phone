using Barber_Phone.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Barber_Phone.Datos
{
    class DDireccionB
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
        /// Metodo para obtener los sectores en base a la direccion de las barberias. 
        /// utiliza el sector como parametro de busqueda   
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DireccionB>> GetDireccionBSector()
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/PostCitas/GetDireccionBSector.php";
            /*Consumimos el webservices alojado en la URL y obtenemos un array con los datos de los sectores*/
            var res = await client.GetAsync(URL);

            /*Evaluamos la respuesta HTTP recibida en res fue satisfactoria*/
            if (res.IsSuccessStatusCode)
            {
                //Recibimos el contenido de res y lo almacenamos en un string
                string content = await res.Content.ReadAsStringAsync();

                /*Convertimos el contenido del Json a un array de objetos de tipo DireccionB y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<DireccionB>>(content);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<DireccionB>();
        }
    }
}
