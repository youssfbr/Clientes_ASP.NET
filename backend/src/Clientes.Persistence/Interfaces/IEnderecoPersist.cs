using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Persistence.Interfaces
{
    public interface IEnderecoPersist
    {
        Task<Endereco[]> GetAllEnderecosAsync();
        Task<Endereco[]> GetAllEnderecosByNome(string nome);
        Task<Endereco> GetEnderecoById(int EnderecoId);
    }
}