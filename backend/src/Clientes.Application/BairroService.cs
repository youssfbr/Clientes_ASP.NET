using System;
using System.Threading.Tasks;
using Clientes.Application.Interfaces;
using Clientes.Domain.Models;
using Clientes.Persistence.Interfaces;

namespace Clientes.Application
{
    public class BairroService : IBairroService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IBairroPersist _bairroPersist;

        public BairroService(IGeralPersist geralPersist, IBairroPersist bairroPersist)
        {
            _geralPersist = geralPersist;
            _bairroPersist = bairroPersist;
        }
        public async Task<Bairro> AddBairro(Bairro model)
        {
            try
            {
                 _geralPersist.Add<Bairro>(model);

                 if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _bairroPersist.GetBairroByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bairro> UpdateBairro(int id, Bairro model)
        {
            try
            {
                var bairro = await _bairroPersist.GetBairroByIdAsync(id);
                if (bairro == null) return null; 

                model.Id = bairro.Id;                

                _geralPersist.Update(model);
                
                if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _bairroPersist.GetBairroByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Boolean> DeleteBairro(int id)
        {
            try
            {
                var bairro = await _bairroPersist.GetBairroByIdAsync(id);
                if (bairro == null) return false;
              
                _geralPersist.Delete<Bairro>(bairro);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public async Task<Bairro[]> GetAllBairrosAsync()
        {
            try
            {
                var bairros = await _bairroPersist.GetAllBairrosAsync();
                if (bairros == null) return null;

                return bairros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public async Task<Bairro[]> GetAllBairrosByNomeAsync(string nome)
        {
            try
            {
                 var bairros = await _bairroPersist.GetAllBairrosByNomeAsync(nome);
                 if (bairros == null) return null;

                 return bairros;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);  
            }
        }

        public async Task<Bairro> GetBairroByIdAsync(int id)
        {
            try
            {
                 var bairro = await _bairroPersist.GetBairroByIdAsync(id);
                 if (bairro == null) return null;

                 return bairro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                  
            }
        }
        
    }
}