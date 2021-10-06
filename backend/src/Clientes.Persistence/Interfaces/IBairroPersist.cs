using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Persistence.Interfaces
{
    public interface IBairroPersist
    {
        Task<Bairro[]> GetAllBairrosAsync();
        Task<Bairro[]> GetAllBairrosByNome(string nome);
        Task<Bairro> GetBairroById(int BairroId);
    }
}