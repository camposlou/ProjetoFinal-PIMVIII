
namespace Domain.Utils
{
    public interface IDataBaseSettings
    {
        string PessoaCollectionName { get; set; }
        string EnderecoCollectionName { get; set; }
        string TelefoneCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DataBaseName { get; set; }
    }
}
