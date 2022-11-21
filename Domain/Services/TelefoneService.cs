using Domain.DTO;
using Domain.Models;
using Domain.Utils;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace Domain.Services
{
    public class TelefoneService
    {
        private readonly IMongoCollection<Telefone> _telefone;

        public TelefoneService(IDataBaseSettings settings)
        {
            var telefone = new MongoClient(settings.ConnectionString);
            var database = telefone.GetDatabase(settings.DataBaseName);
            _telefone = database.GetCollection<Telefone>(settings.TelefoneCollectionName);
        }

        public TelefoneService() { }

        public Telefone Create(Telefone telefoneDB)
        {
            _telefone.InsertOne(telefoneDB);
            return telefoneDB;
        }
        public List<Telefone> Get() =>
            _telefone.Find(telefone => true).ToList();

        public Telefone GetTipo(string tipo) =>
           _telefone.Find(telefone => telefone.Tipo == tipo).FirstOrDefault();

        public void Update(string cpf, Telefone telefoneIn) =>
            _telefone.ReplaceOne(telefone => telefone.PessoaCpf == cpf, telefoneIn);

        public void Remove(string cpf) =>
           _telefone.DeleteOne(telefone => telefone.PessoaCpf == cpf);
    }
}
