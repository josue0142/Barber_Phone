using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Barber_Phone.Clases;

namespace Barber_Phone.Datos
{
    class DBarbero
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
        /// Metodo para obtener los datos del barbero que realiza el login en la aplicacion. 
        /// utiliza el correo como parametro de busqueda
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Barbero>> GetExisteBarbero(string correo)
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/GetUsers/GetExisteBarbero.php";
            /*Consumimos el webservices alojado en la URL y obtenemos un array con los datos del usuario en base al 
            correo recibido por parametro*/
            var res = await client.GetAsync(URL + "?correo=" + correo + " ");

            /*Evaluamos la respuesta HTTP recibida en res fue satisfactoria*/
            if (res.IsSuccessStatusCode)
            {
                //Recibimos el contenido de res y lo almacenamos en un string
                string content = await res.Content.ReadAsStringAsync();

                /*Convertimos el contenido del Json a un array de objetos de tipo Babero y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<Barbero>>(content);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Barbero>();
        }

        /*public async Task<IEnumerable<Barbero>> VerificarBarberoLogin(string correo, string contraseña)
        {
            string uri = "https://bookshop2.000webhostapp.com/WebServicesXamarin/barberos.php";
            var content = new StringContent("{\"correo:\":\"" + correo + "\",\"contraseña:\":\"" + contraseña + "\"}");
            HttpClient client = GetClient();
            var res = await client.PostAsync(uri, content);

            if (res.IsSuccessStatusCode)
            {
                string result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Barbero>>(result);
            }

            return Enumerable.Empty<Barbero>();
        }*/
    }
}
