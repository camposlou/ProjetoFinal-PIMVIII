using System.Net.Http;
using System.Threading.Tasks;
using Domain.Models;
using Newtonsoft.Json;

namespace Domain.Services
{
    public class EnderecoServiceAPI
    {

        private Endereco _endereco;

        public EnderecoServiceAPI() { }

        public async Task<Endereco> MainAsync(string cep)
        {

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");

                var enderecoJson = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return _endereco = JsonConvert.DeserializeObject<Endereco>(enderecoJson);

                else
                    return null;
            }
        }


    }
}
