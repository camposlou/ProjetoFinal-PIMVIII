using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Pessoa
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }

        [Required(ErrorMessage = "CPF Precisa de 11 Digitos...")]
        [StringLength(14)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é Campo Obrigatorio!")]
        [StringLength(30)]
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public Telefone Telefone { get; set; }
    }
}
