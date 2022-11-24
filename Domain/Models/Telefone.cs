using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Telefone
    {

        [MaxLength(3)]
        public string DDD { get; set; }

        [MaxLength(14)]
        public string Numero { get; set; }

        [MaxLength(30)]
        public string Tipo { get; set; }

       
        [JsonIgnore]
        public string PessoaCpf { get; set; }
    }
}
