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
        /// Metodo para obtener los datos de las citas(incompletadas), relacionados con el correo del cliente que esta 
        /// logeado en la apliacion.
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Cita>> GetCitaCliente(string correo)
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/GetCitas/GetCitaCliente.php";
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

        /// <summary>
        /// Metodo para obtener los datos de las citas(Completadas), relacionados con el correo del cliente que esta 
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



        /// <summary>
        /// Metodo para obtener los datos de las citas(Completadas), relacionados con el correo del barbero que esta 
        /// logeado en la apliacion.
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Cita>> GetHistorialCitaBarbero(string correo)
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/GetCitas/GetHistorialBarbero.php";
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

        /// <summary>
        /// Metodo para obtener los datos de las citas(No completadas), relacionados con el correo del barbero que esta 
        /// logeado en la apliacion.
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Cita>> GetAgendaBarbero(string correo)
        {
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/GetCitas/GetAgendaBarbero.php";
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

        public async Task<IEnumerable<Cita>> PostCita(string sector, string nBarberia, string tServicio,
        string fecha, string hora, string id_cliente)
        {
            //Task<IEnumerable<Cita>>
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/PostCitas/PostCita.php";

            //Creamos una tupla con los datos del cliente y lo almacenamos en la variable content 
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("sector", sector),
                new KeyValuePair<string, string>("barberia", nBarberia),
                new KeyValuePair<string, string>("servicio", tServicio),
                new KeyValuePair<string, string>("fecha", fecha),
                new KeyValuePair<string, string>("hora",hora),
                new KeyValuePair<string, string>("fk_Clientes",id_cliente),
            }
            );

            
            //Consumimos el webservices alojado en la URL, enviamos mediante el metodo PostAsync los datos del cliente
             // y obtenemos un array con los datos del cliente en base a la insersion realizada en la BD
            var res = await client.PostAsync(URL, content);

            //Evaluamos la respuesta HTTP recibida en res fue satisfactoria
           // if (res.IsSuccessStatusCode)
           // {
                //Recibimos el contenido de res y lo almacenamos en un string
               // string aux = await res.Content.ReadAsStringAsync();

                //Convertimos el contenido del Json a un array de objetos de tipo Cliente y luego
                //retornamos el array de objetos
                //return JsonConvert.DeserializeObject < IEnumerable<Cita>(aux);
           // }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Cita>();
        }

        public async void EliminarCita(int id_Cita)
        {
            //Task<IEnumerable<Cita>>
            HttpClient client = GetClient();
            const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/Delete/EliminarCita.php";

            //Creamos una tupla con los datos del cliente y lo almacenamos en la variable content 
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("id_Cita", id_Cita.ToString()),
            }
            );


            //Consumimos el webservices alojado en la URL, enviamos mediante el metodo PostAsync los datos del cliente
            // y obtenemos un array con los datos del cliente en base a la insersion realizada en la BD
            var res = await client.PostAsync(URL, content);

            //Evaluamos la respuesta HTTP recibida en res fue satisfactoria
            // if (res.IsSuccessStatusCode)
            // {
            //Recibimos el contenido de res y lo almacenamos en un string
            // string aux = await res.Content.ReadAsStringAsync();

            //Convertimos el contenido del Json a un array de objetos de tipo Cliente y luego
            //retornamos el array de objetos
            //return JsonConvert.DeserializeObject < IEnumerable<Cita>(aux);
            // }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            //return Enumerable.Empty<Cita>();
        }
    }
}
