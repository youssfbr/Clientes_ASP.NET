using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Application.Interfaces
{
    public interface IBairroService
    {
        Task<Bairro> AddBairro(Bairro model);        
        Task<Bairro> UpdateBairro(int id, Bairro model);
        Task<bool> DeleteBairro(int id);

        Task<Bairro[]> GetAllBairrosAsync();
        Task<Bairro[]> GetAllBairrosByNomeAsync(string nome);
        Task<Bairro> GetBairroByIdAsync(int id);     
    }
}