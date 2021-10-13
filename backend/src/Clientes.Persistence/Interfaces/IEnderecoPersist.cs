using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Persistence.Interfaces
{
    public interface IEnderecoPersist
    {
        Task<Endereco[]> GetAllEnderecosAsync();
        Task<Endereco[]> GetAllEnderecosByNomeAsync(string nome);
        Task<Endereco> GetEnderecoByIdAsync(int EnderecoId);
    }
}