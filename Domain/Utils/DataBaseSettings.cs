
namespace Domain.Utils
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string PessoaCollectionName { get; set; }
        public string EnderecoCollectionName { get; set; }
        public string TelefoneCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
