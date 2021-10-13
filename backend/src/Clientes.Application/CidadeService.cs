using System;
using System.Threading.Tasks;
using Clientes.Application.Interfaces;
using Clientes.Domain.Models;
using Clientes.Persistence.Interfaces;

namespace Clientes.Application
{
    public class CidadeService : ICidadeService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ICidadePersist _cidadePersist;

        public CidadeService(IGeralPersist geralPersist, ICidadePersist cidadePersist)
        {
            _geralPersist = geralPersist;
            _cidadePersist = cidadePersist;
        }
        public async Task<Cidade> AddCidade(Cidade model)
        {
            try
            {
                _geralPersist.Add<Cidade>(model);
                 if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _cidadePersist.GetCidadeByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public async Task<Cidade> UpdateCidade(int id, Cidade model)
        {
            try
            {
                var cidade = await _cidadePersist.GetCidadeByIdAsync(id);
                if (cidade == null) return null; 

                model.Id = cidade.Id;                

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _cidadePersist.GetCidadeByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                                
            }
        }

        public async Task<bool> DeleteCidade(int id)
        {
            try
            {
                var cidade = await _cidadePersist.GetCidadeByIdAsync(id);
                if (cidade == null) return false;
                
                _geralPersist.Delete<Cidade>(cidade);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);                                
            }           
        }

        public async Task<Cidade[]> GetAllCidadesAsync()
        {
            try
            {
                var cidades = await _cidadePersist.GetAllCidadesAsync();
                if (cidades == null) return null;

                return cidades;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message); 
            }
        }

        public async Task<Cidade[]> GetAllCidadesByNomeAsync(string nome)
        {
            try
            {
                var cidades = await _cidadePersist.GetAllCidadesByNomeAsync(nome);
                if (cidades == null) return null;

                return cidades;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message); 
            }
        }

        public async Task<Cidade> GetCidadeByIdAsync(int id)
        {
             try
            {
                var cidade = await _cidadePersist.GetCidadeByIdAsync(id);
                if (cidade == null) return null;

                return cidade;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message); 
            }
        }
        
    }
}