using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace Domain.DTO
{

    public class EnderecoDTO
    {
        [Required]
        [StringLength(9)]
        [JsonProperty("cep")]
        public string Cep { get; set; }

        [StringLength(10)]
        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("numero")]
        public int Numero { get; set; }


    }
}
