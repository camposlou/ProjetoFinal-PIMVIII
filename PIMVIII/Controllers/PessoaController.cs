using Domain.DTO;
using Domain.Models;
using Domain.Services;
using Domain.Validacoes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PIMVIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _pessoaServices;
        private readonly EnderecoServiceDB _enderecoServices;
        private readonly TelefoneService _telefoneServices;

        #region Metdodo Construtor
        public PessoaController(PessoaService pessoaService, EnderecoServiceDB enderecoService, TelefoneService telefoneService)
        {
            _pessoaServices = pessoaService;
            _enderecoServices = enderecoService;
            _telefoneServices = telefoneService;


        }
        #endregion

        #region Metodo Cadastrar Pessoa
        [HttpPost("Cadastro", Name = "GetPessoa")]
        public ActionResult<Pessoa> CreateDTO(PessoaPostDTO pessoaIn)
        {
            if (!PessoaValidate.ValidateCpf(pessoaIn.Cpf)) return BadRequest("CPF inválido!");

            var cpf = PessoaValidate.RemoveCharactersDocument(pessoaIn.Cpf);
            cpf = PessoaValidate.AddCharactersDocument(cpf);

            var pessoa = _pessoaServices.GetCpf(cpf);

            if (pessoa == null)
            {
                pessoa = new();
                pessoa.Cpf = cpf;                               
                pessoa.Nome = pessoaIn.Nome;
               
                pessoa.Telefone = pessoaIn.Telefone;
                pessoa.Telefone.PessoaCpf = pessoa.Cpf;

                var endereco = new EnderecoServiceAPI().MainAsync(pessoaIn.Endereco.Cep).Result;
                endereco.Numero = pessoaIn.Endereco.Numero;
                endereco.Complemento = pessoaIn.Endereco.Complemento;
                endereco.PessoaCpf = pessoa.Cpf;
                pessoa.Endereco = endereco;

                _enderecoServices.Create(pessoa.Endereco);
                _telefoneServices.Create(pessoa.Telefone);
                _pessoaServices.Create(pessoa);

                return Created("GetPessoa", pessoa);
            }
            else
            {
                return BadRequest("CPF Já está Cadastrado!");
            }
         
        }
        #endregion

        #region Metodo Buscar Lista de Pessoas Cadastradas
        [HttpGet("List")]
        public ActionResult<List<Pessoa>> Get() => _pessoaServices.Get();
        #endregion

        #region Metodo Buscar Pessoa Cadastrada por CPF
        [HttpGet("cpf")]
        public ActionResult<Pessoa> Get(string cpf)
        {
            if (PessoaValidate.ValidateCpf(cpf))
            {
                var pessoa = _pessoaServices.GetCpf(PessoaValidate.MaskCPF(cpf));
                if (pessoa == null)
                {
                    return BadRequest("Cadastro de Pessoa Não Encontrado!");
                }
                else
                {
                    return Ok(pessoa);
                }

            }
            else
            {
                return BadRequest("CPF Informado Não é valido!");
            }
        }
        #endregion

        #region Metodo para Atualizar Cadastro
        [HttpPut("Cpf")]
        public ActionResult<Pessoa> Update(string cpf, PessoaUpdateDTO pessoaIn)
        {
            if (!PessoaValidate.ValidateCpf(cpf)) return BadRequest("CPF inválido!");

            cpf = PessoaValidate.RemoveCharactersDocument(cpf);
            cpf = PessoaValidate.AddCharactersDocument(cpf);

            var pessoa = _pessoaServices.GetCpf(cpf);

            if (pessoa == null) return BadRequest("Cadastro de Pessoa Não Encontrado!");

            pessoa.Nome = pessoaIn.Nome;

            var endereco = new EnderecoServiceAPI().MainAsync(pessoaIn.Endereco.Cep).Result;
            endereco.Numero = pessoaIn.Endereco.Numero;
            endereco.Complemento = pessoaIn.Endereco.Complemento;
            endereco.PessoaCpf = pessoa.Cpf;
            pessoa.Endereco = endereco;

            pessoa.Telefone = pessoaIn.Telefone;
            pessoa.Telefone.PessoaCpf = pessoa.Cpf;

            _pessoaServices.Update(cpf, pessoa);
            _enderecoServices.Update(cpf, pessoa.Endereco);
            _telefoneServices.Update(cpf, pessoa.Telefone);


            return Ok("Cadastro atualizado com sucesso!!!");
        }
        #endregion

        #region Metodo para Deletar Cadastro
        [HttpDelete("Cpf")]
        public ActionResult<Pessoa> Delete(string cpf)
        {

            if (!PessoaValidate.ValidateCpf(cpf)) return BadRequest("CPF inválido!");

            cpf = PessoaValidate.RemoveCharactersDocument(cpf);
            cpf = PessoaValidate.AddCharactersDocument(cpf);

            var pessoa = _pessoaServices.GetCpf(cpf);
            if (pessoa == null) return BadRequest("Cadastro de Pessoa Não Encontrado!");

            _pessoaServices.Remove(cpf);
            _enderecoServices.Remove(cpf);
            _telefoneServices.Remove(cpf);

            return Ok("Cadastro removido com Sucesso!!!");

        }
        #endregion


    }
}
