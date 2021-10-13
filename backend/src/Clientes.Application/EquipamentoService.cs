using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Application.Interfaces;
using Clientes.Domain.Models;
using Clientes.Persistence.Interfaces;

namespace Clientes.Application
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEquipamentoPersist _equipamentoPersist;

        public EquipamentoService(IGeralPersist geralPersist, IEquipamentoPersist equipamentoPersist)
        {
            _geralPersist = geralPersist;
            _equipamentoPersist = equipamentoPersist;
        }

        public async Task<Equipamento> AddEquipamento(Equipamento model)
        {
            try
            {
                 _geralPersist.Add<Equipamento>(model);

                 if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _equipamentoPersist.GetEquipamentoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Equipamento> UpdateEquipamento(int id, Equipamento model)
        {
            try
            {
                var equipamento = await _equipamentoPersist.GetEquipamentoByIdAsync(id);
                if (equipamento == null) return null; 

                model.Id = equipamento.Id;                

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _equipamentoPersist.GetEquipamentoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEquipamento(int id)
        {
            try
            {
                var equipamento = await _equipamentoPersist.GetEquipamentoByIdAsync(id);
                if (equipamento == null) return false;
              
                _geralPersist.Delete<Equipamento>(equipamento);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public async Task<Equipamento[]> GetAllEquipamentosAsync()
        {
            try
            {
                var equipamentos = await _equipamentoPersist.GetAllEquipamentosAsync();
                if (equipamentos == null) return null;

                return equipamentos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public async Task<Equipamento[]> GetAllEquipamentosByModeloAsync(string modelo)
        {
            try
            {
                 var equipamentos = await _equipamentoPersist.GetAllEquipamentosByModeloAsync(modelo);
                 if (equipamentos == null) return null;

                 return equipamentos;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);  
            }
        }

        public async Task<Equipamento> GetEquipamentoByIdAsync(int id)
        {
            try
            {
                 var equipamento = await _equipamentoPersist.GetEquipamentoByIdAsync(id);
                 if (equipamento == null) return null;

                 return equipamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                  
            }
        }

        public async Task<Equipamento> GetEquipamentoByNumeroSerieAsync(string numeroSerie)
        {
            try
            {
                 var equipamentos = await _equipamentoPersist.GetEquipamentoByNumeroSerieAsync(numeroSerie);
                 if (equipamentos == null) return null;

                 return equipamentos;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);  
            }
        }
        
    }
}