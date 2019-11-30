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
    class DCliente
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
        /// Metodo para obtener los datos del cliente que realiza el login en la aplicacion. 
        /// utiliza el correo como parametro de busqueda
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Cliente>> GetExisteCliente(string correo)
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/GetUsers/GetExisteCliente.php";
            /*Consumimos el webservices alojado en la URL y obtenemos un array con los datos del usuario en base al 
            correo recibido por parametro*/
            var res = await client.GetAsync(URL + "?correo=" + correo + "");

            /*Evaluamos la respuesta HTTP recibida en res fue satisfactoria*/
            if (res.IsSuccessStatusCode)
            {
                //Recibimos el contenido de res y lo almacenamos en un string
                string content = await res.Content.ReadAsStringAsync();

                /*Convertimos el contenido del Json a un array de objetos de tipo Cliente y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<Cliente>>(content);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Cliente>();
        }

        /// <summary>
        /// Metodo para insertar los datos del cliente que realiza un registro en la aplicacion. 
        /// recibe como parametro un objeto Cliente con los datos del cliente que desea registrarse. 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Cliente>> PostCliente(Cliente cliente)
        {

            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/PostUsers/PostCliente.php";
             
            //Creamos una tupla con los datos del cliente y lo almacenamos en la variable content 
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("primer_Nombre", cliente.Primer_Nombre),
                new KeyValuePair<string, string>("primer_Apellido", cliente.Primer_Apellido),
                new KeyValuePair<string, string>("correo", cliente.Correo),
                new KeyValuePair<string, string>("contraseña", cliente.Contraseña),
                new KeyValuePair<string, string>("numero_Telefono",cliente.Numero_Telefono),
            }
            );

            /*Consumimos el webservices alojado en la URL, enviamos mediante el metodo PostAsync los datos del cliente
             * y obtenemos un array con los datos del cliente en base a la insersion realizada en la BD*/
            var res = await client.PostAsync(URL, content);

            /*Evaluamos la respuesta HTTP recibida en res fue satisfactoria*/
            if (res.IsSuccessStatusCode)
            {
                //Recibimos el contenido de res y lo almacenamos en un string
                string aux = await res.Content.ReadAsStringAsync();

                /*Convertimos el contenido del Json a un array de objetos de tipo Cliente y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<Cliente>>(aux);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Cliente>();
        }

        public async Task<IEnumerable<Cliente>> UpdateCliente(Cliente cliente)
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/UpdatUsers/UpdateCliente.php";

            //Creamos una tupla con los datos del cliente y lo almacenamos en la variable content 
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("correo", cliente.Correo),
                new KeyValuePair<string, string>("contraseña", cliente.Contraseña),
                new KeyValuePair<string, string>("numero_Telefono",cliente.Numero_Telefono),
            }
            );

            /*Consumimos el webservices alojado en la URL, enviamos mediante el metodo PostAsync los datos del cliente
             * y obtenemos un array con los datos del cliente en base a la insersion realizada en la BD*/
            var res = await client.PostAsync(URL, content);

            /*Evaluamos la respuesta HTTP recibida en res fue satisfactoria*/
            if (res.IsSuccessStatusCode)
            {
                //Recibimos el contenido de res y lo almacenamos en un string
                string aux = await res.Content.ReadAsStringAsync();

                /*Convertimos el contenido del Json a un array de objetos de tipo Cliente y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<Cliente>>(aux);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Cliente>();
        }

    }
}
