using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Persistence.Interfaces
{
    public interface ICidadePersist
    {   
        Task<Cidade[]> GetAllCidadesAsync();
        Task<Cidade[]> GetAllCidadesByNomeAsync(string nome);
        Task<Cidade> GetCidadeByIdAsync(int BairroId);
    }
}