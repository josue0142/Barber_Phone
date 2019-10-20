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
        //Url del webservice cliente.php
        const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/clientes.php";
        
        //Metodo para crear el httpclient
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }

        //Metodo para obtener el archivo json desde el web service y convertir el contenido
        //en una lista de objetos Cliente. 
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            HttpClient client = GetClient();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<Cliente>>(content);
            }

            return Enumerable.Empty<Cliente>();
        }

    }
}
