using Domain.Models;
using Domain.Utils;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Domain.Services
{
    public class EnderecoServiceDB
    {
        private readonly IMongoCollection<Endereco> _endereco;

        public EnderecoServiceDB(IDataBaseSettings settings)
        {
            var endereco = new MongoClient(settings.ConnectionString);
            var database = endereco.GetDatabase(settings.DataBaseName);
            _endereco = database.GetCollection<Endereco>(settings.EnderecoCollectionName);
        }

        public Endereco Create(Endereco endereco)
        {
            _endereco.InsertOne(endereco);
            return endereco;
        }

        public List<Endereco> Get() =>
            _endereco.Find(endereco => true).ToList();


        public Endereco GetCep(string cep) =>
            _endereco.Find(endereco => endereco.Cep == cep).FirstOrDefault();

        public Endereco GetCpf(string cpf) =>
           _endereco.Find<Endereco>(endereco => endereco.PessoaCpf == cpf).FirstOrDefault();

        public void Update(string cpf, Endereco enderecoIn) =>
            _endereco.ReplaceOne(endereco => endereco.PessoaCpf == cpf, enderecoIn);


        public void Remove(string cpf) =>
          _endereco.DeleteOne(endereco => endereco.PessoaCpf == cpf);


    }
}
