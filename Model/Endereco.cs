using System.Text.Json.Serialization;

namespace Gerar_PDF.Model
{
    public class Endereco
    {
        [JsonPropertyName("cep")]
        public string CEP { get; set; }
        [JsonPropertyName("uf")]
        public string Estado { get; set; }
        [JsonPropertyName("localidade")]
        public string Cidade { get; set; }
        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }
    }
}
