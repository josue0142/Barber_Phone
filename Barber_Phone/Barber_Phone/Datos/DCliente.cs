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

                /*Convertimos el contenido del Json a un array de objetos de tipo Babero y luego
                retornamos el array de objetos*/
                return JsonConvert.DeserializeObject<IEnumerable<Cliente>>(content);
            }

            //En caso de no encontrar datos en res devolvemos un enumerable vacio.
            return Enumerable.Empty<Cliente>();
        }


        /*public async Task<IEnumerable<Cliente>> VerificarClienteLogin(string correo)
        {
            string uri = "https://bookshop2.000webhostapp.com/WebServicesXamarin/clientes.php";
            //string jsonData = "{\"\"correo\"\": \"\""+correo+"\"\"}";
            string aux = @"{""correo"":""josuejjimenezd@gmail.com""}";
            string jsonData = JsonConvert.SerializeObject(aux);
            var content = new StringContent(jsonData);
            HttpClient client = GetClient();
            var res = await client.PostAsync(uri, content);

            if (res.IsSuccessStatusCode)
            {
                string result = await res.Content.ReadAsStringAsync(); 
                return JsonConvert.DeserializeObject<IEnumerable<Cliente>>(result);
            }

            return Enumerable.Empty<Cliente>();
        } */



        /*
        public async Task ejemplo()
        {
            var uri = "https://api.domain.com/v1/products";
            var content = new StringContent("{\" nombre: \ ": \" Xamarin Shirt \ "}");
            Cliente HttpClient = nuevo HttpClient();
            respuesta var = esperar cliente.PostAsync(uri, contenido);


        }
        */

        /*public async Task SaveTodoItemAsync(Cliente cliente, bool isNewItem = false)
        {   
            var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));

            ...
  var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await _client.PostAsync(uri, content);
            }
            ...

  if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tTodoItem successfully saved.");

            }
            ...
}*/

        /*
                var user = User.Text;
                var pass = Pass.Text;
        try
                {

                    var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("username", user));
                    postData.Add(new KeyValuePair<string, string>("password", pass));

                    var content = new FormUrlEncodedContent(postData);

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("Http://*.*.*.*:81");

                var response = await client.PostAsync("Http://*.*.*.*:81/Cinfo.php", content);
                result = response.Content.ReadAsStringAsync().Result;

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.ToString(), "Ok");
                    return;
                }*/
    }
}
