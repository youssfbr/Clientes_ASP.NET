using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Persistence.Interfaces
{
    public interface IEquipamentoMarcaPersist
    {
        Task<EquipamentoMarca[]> GetAllEquipamentosMarcasAsync();
        Task<EquipamentoMarca[]> GetAllEquipamentosMarcasByMarcaAsync(string marca);        
        Task<EquipamentoMarca> GetEquipamentoMarcaByIdAsync(int id);
    }
}