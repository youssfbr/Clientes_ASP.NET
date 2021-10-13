using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Persistence.Interfaces
{
    public interface IBairroPersist
    {
        Task<Bairro[]> GetAllBairrosAsync();
        Task<Bairro[]> GetAllBairrosByNomeAsync(string nome);
        Task<Bairro> GetBairroByIdAsync(int BairroId);
    }
}