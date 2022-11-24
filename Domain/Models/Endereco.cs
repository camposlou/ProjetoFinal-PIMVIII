using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{

    public class Endereco
    {
        [StringLength(9)]
        [Newtonsoft.Json.JsonProperty("cep")]
        public string Cep { get; set; }

        [StringLength(100)]
        [Newtonsoft.Json.JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [Newtonsoft.Json.JsonProperty("numero")]
        public int Numero { get; set; }

        [StringLength(10)]
        [Newtonsoft.Json.JsonProperty("complemento")]
        public string Complemento { get; set; }

        [StringLength(30)]
        [Newtonsoft.Json.JsonProperty("bairro")]
        public string Bairro { get; set; }

        [StringLength(50)]
        [Newtonsoft.Json.JsonProperty("localidade")]
        public string Cidade { get; set; }

        [StringLength(25)]
        [Newtonsoft.Json.JsonProperty("uf")]
        public string Estado { get; set; }

        
        [JsonIgnore]
        public string PessoaCpf { get; set; }
    }

}
