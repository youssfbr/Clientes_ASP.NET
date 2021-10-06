using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Persistence.Interfaces
{
    public interface ICidadePersist
    {   
        Task<Cidade[]> GetAllCidadesAsync();
        Task<Cidade[]> GetAllCidadesByNome(string nome);
        Task<Cidade> GetCidadeById(int BairroId);
    }
}