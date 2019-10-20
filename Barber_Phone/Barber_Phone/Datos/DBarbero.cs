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
        //Url del webservice barberos.php
        const string URL = "https://bookshop2.000webhostapp.com/WebServicesXamarin/barberos.php";

        //Metodo para crear el httpclient
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }

        //Metodo para obtener el archivo json desde el web service y convertir el contenido
        //en una lista de objetos barberos. 
        public async Task<IEnumerable<Barbero>> GetBarberos()
        {
            HttpClient client = GetClient();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<Barbero>>(content);
            }

            return Enumerable.Empty<Barbero>();
        }
    }
}
