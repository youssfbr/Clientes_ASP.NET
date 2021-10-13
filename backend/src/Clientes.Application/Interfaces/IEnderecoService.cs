using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> AddEndereco(Endereco model);        
        Task<Endereco> UpdateEndereco(int id, Endereco model);
        Task<bool> DeleteEndereco(int id);

        Task<Endereco[]> GetAllEnderecosAsync();
        Task<Endereco[]> GetAllEnderecosByNomeAsync(string nome);
        Task<Endereco> GetEnderecoByIdAsync(int id);     
    }
}