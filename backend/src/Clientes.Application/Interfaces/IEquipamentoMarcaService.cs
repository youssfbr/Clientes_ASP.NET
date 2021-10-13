using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Application.Interfaces
{
    public interface IEquipamentoMarcaService
    {
        Task<EquipamentoMarca> AddEquipamentoMarca(EquipamentoMarca model);        
        Task<EquipamentoMarca> UpdateEquipamentoMarca(int id, EquipamentoMarca model);
        Task<bool> DeleteEquipamentoMarca(int id);


        Task<EquipamentoMarca[]> GetAllEquipamentosMarcasAsync();
        Task<EquipamentoMarca[]> GetAllEquipamentosMarcasByMarcaAsync(string marca);        
        Task<EquipamentoMarca> GetEquipamentoMarcaByIdAsync(int id);       
    }
}