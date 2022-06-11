using Gerar_PDF.Model;
using System.Text.Json;

namespace Gerar_PDF.Services
{
    public class ServiceAPI
    {
        public static async Task<Endereco> GetEnderecoAsync(string cep)
        {
            Uri urlBase = new($"https://viacep.com.br/ws/{cep}/json/");
            using(HttpClient http = new())
            {
                HttpResponseMessage response = await http.GetAsync(urlBase);
                response.EnsureSuccessStatusCode();
                return  JsonSerializer.Deserialize<Endereco>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
