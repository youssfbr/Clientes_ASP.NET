using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Persistence.Interfaces
{
    public interface IClientePersist
    {
        Task<Cliente[]> GetAllClientesAsync();
        Task<Cliente[]> GetAllClientesByNomeAsync(string nome);
        Task<Cliente> GetClienteByIdAsync(int ClienteId);     
    }
}