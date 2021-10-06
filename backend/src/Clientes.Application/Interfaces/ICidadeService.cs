using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Application.Interfaces
{
    public interface ICidadeService
    {
        Task<Cidade> AddCidade(Cidade model);        
        Task<Cidade> UpdateCidade(int id, Cidade model);
        Task<bool> DeleteCidade(int id);

        Task<Cidade[]> GetAllCidadesAsync();
        Task<Cidade[]> GetAllCidadesByNomeAsync(string nome);
        Task<Cidade> GetCidadeByIdAsync(int id);     
    }
}