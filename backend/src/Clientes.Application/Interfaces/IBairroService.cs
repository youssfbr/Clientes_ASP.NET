using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Application.Interfaces
{
    public interface IBairroService
    {
        Task<Bairro> AddBairro(Bairro model);        
        Task<Bairro> UpdateBairro(int bairroId, Bairro model);
        Task<bool> DeleteBairro(int bairroId);

        Task<Bairro[]> GetAllBairrosAsync();
        Task<Bairro[]> GetAllBairrosByNomeAsync(string nome);
        Task<Bairro> GetBairroByIdAsync(int bairroId);     
    }
}