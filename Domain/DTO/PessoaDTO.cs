using Domain.Models;
using Domain.Validacoes;
using System.ComponentModel.DataAnnotations;


namespace Domain.DTO
{
    public class PessoaDTO
    {
        [Required(ErrorMessage = "CPF Precisa de 11 Digitos...")]
        [StringLength(14)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é Campo Obrigatorio!")]
        [StringLength(30)]
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public Telefone Telefone { get; set; }

        public PessoaDTO(string cpf)
        {
            Cpf = PessoaValidate.MaskCPF(cpf);
        }
    }
    public class PessoaUpdateDTO
    {
        [StringLength(30)]
        public string Nome { get; set; }

        public EnderecoDTO Endereco { get; set; }

        public Telefone Telefone { get; set; }

    }

    public class PessoaPostDTO
    {
        [StringLength(30)]
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public EnderecoDTO Endereco { get; set; }

        public Telefone Telefone { get; set; }

    }
}
