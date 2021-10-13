using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Persistence.Interfaces
{
    public interface IEquipamentoPersist
    {
        Task<Equipamento[]> GetAllEquipamentosAsync();
        Task<Equipamento[]> GetAllEquipamentosByModeloAsync(string modelo);
        Task<Equipamento> GetEquipamentoByNumeroSerieAsync(string numeroSerie);
        Task<Equipamento> GetEquipamentoByIdAsync(int BairroId);
    }
}