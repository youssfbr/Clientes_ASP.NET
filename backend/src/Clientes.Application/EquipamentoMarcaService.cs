using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Application.Interfaces;
using Clientes.Domain.Models;
using Clientes.Persistence.Interfaces;

namespace Clientes.Application
{
    public class EquipamentoMarcaService : IEquipamentoMarcaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEquipamentoMarcaPersist _equipamentoMarcaPersist;

        public EquipamentoMarcaService(IGeralPersist geralPersist, IEquipamentoMarcaPersist equipamentoMarcaPersist)
        {
            _geralPersist = geralPersist;
            _equipamentoMarcaPersist = equipamentoMarcaPersist;
        }
        public async Task<EquipamentoMarca> AddEquipamentoMarca(EquipamentoMarca model)
        {
              try
            {
                 _geralPersist.Add<EquipamentoMarca>(model);

                 if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _equipamentoMarcaPersist.GetEquipamentoMarcaByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EquipamentoMarca> UpdateEquipamentoMarca(int id, EquipamentoMarca model)
        {
            try
            {
                var equipamentoMarca = await _equipamentoMarcaPersist.GetEquipamentoMarcaByIdAsync(id);
                if (equipamentoMarca == null) return null; 

                model.Id = equipamentoMarca.Id;                

                _geralPersist.Update(model);
                
                if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _equipamentoMarcaPersist.GetEquipamentoMarcaByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEquipamentoMarca(int id)
        {
            try
            {
                var equipamentoMarca = await _equipamentoMarcaPersist.GetEquipamentoMarcaByIdAsync(id);
                if (equipamentoMarca == null) return false;
              
                _geralPersist.Delete<EquipamentoMarca>(equipamentoMarca);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public async Task<EquipamentoMarca[]> GetAllEquipamentosMarcasAsync()
        {
            try
            {
                var equipamentoMarcas = await _equipamentoMarcaPersist.GetAllEquipamentosMarcasAsync();
                if (equipamentoMarcas == null) return null;

                return equipamentoMarcas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public async Task<EquipamentoMarca[]> GetAllEquipamentosMarcasByMarcaAsync(string marca)
        {
            try
            {
                 var equipamentoMarcas = await _equipamentoMarcaPersist.GetAllEquipamentosMarcasByMarcaAsync(marca);
                 if (equipamentoMarcas == null) return null;

                 return equipamentoMarcas;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);  
            }
        }

        public async Task<EquipamentoMarca> GetEquipamentoMarcaByIdAsync(int id)
        {
            try
            {
                 var equipamentoMarca = await _equipamentoMarcaPersist.GetEquipamentoMarcaByIdAsync(id);
                 if (equipamentoMarca == null) return null;

                 return equipamentoMarca;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                  
            }
        }        
    }
}