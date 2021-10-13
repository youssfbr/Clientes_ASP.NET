using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Application.Interfaces
{
    public interface IEquipamentoService
    {
        Task<Equipamento> AddEquipamento(Equipamento model);        
        Task<Equipamento> UpdateEquipamento(int id, Equipamento model);
        Task<bool> DeleteEquipamento(int id);

        
        Task<Equipamento[]> GetAllEquipamentosAsync();
        Task<Equipamento[]> GetAllEquipamentosByModeloAsync(string modelo);
        Task<Equipamento> GetEquipamentoByNumeroSerieAsync(string numeroSerie);
        Task<Equipamento> GetEquipamentoByIdAsync(int id);
    }
}