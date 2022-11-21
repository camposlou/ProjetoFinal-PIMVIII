using Domain.Models;
using Domain.Utils;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Domain.Services
{
    public class PessoaService
    {
        private readonly IMongoCollection<Pessoa> _pessoa;

        public PessoaService(IDataBaseSettings settings)
        {
            var pessoa = new MongoClient(settings.ConnectionString);
            var database = pessoa.GetDatabase(settings.DataBaseName);
            _pessoa = database.GetCollection<Pessoa>(settings.PessoaCollectionName);

        }

        public Pessoa Create(Pessoa pessoa)
        {
            _pessoa.InsertOne(pessoa);
            return pessoa;
        }
        public List<Pessoa> Get() =>
            _pessoa.Find<Pessoa>(pessoa => true).ToList();

        public Pessoa GetCpf(string cpf) =>
            _pessoa.Find<Pessoa>(pessoa => pessoa.Cpf == cpf).FirstOrDefault();

        public void Update(string cpf, Pessoa pessoaIn) =>

            _pessoa.ReplaceOne(pessoa => pessoa.Cpf == cpf, pessoaIn);

        public void Remove(string cpf) =>
          _pessoa.DeleteOne(pessoa => pessoa.Cpf == cpf);
    }
}
