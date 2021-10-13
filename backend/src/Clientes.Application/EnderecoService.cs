using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Application.Interfaces;
using Clientes.Domain.Models;
using Clientes.Persistence.Interfaces;

namespace Clientes.Application
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEnderecoPersist _enderecoPersist;

        public EnderecoService(IGeralPersist geralPersist, IEnderecoPersist enderecoPersist)
        {
            _geralPersist = geralPersist;
            _enderecoPersist = enderecoPersist;
        }
        public async Task<Endereco> AddEndereco(Endereco model)
        {
            try
            {
                 _geralPersist.Add<Endereco>(model);
                 if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _enderecoPersist.GetEnderecoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Endereco> UpdateEndereco(int id, Endereco model)
        {
            try
            {
                var endereco = await _enderecoPersist.GetEnderecoByIdAsync(id);
                if (endereco == null) return null; 

                model.Id = endereco.Id;                

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _enderecoPersist.GetEnderecoByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEndereco(int id)
        {
            try
            {
                var endereco = await _enderecoPersist.GetEnderecoByIdAsync(id);
                if (endereco == null) return false;
              
                _geralPersist.Delete<Endereco>(endereco);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public async Task<Endereco[]> GetAllEnderecosAsync()
        {
            try
            {
                var enderecos = await _enderecoPersist.GetAllEnderecosAsync();
                if (enderecos == null) return null;

                return enderecos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public async Task<Endereco[]> GetAllEnderecosByNomeAsync(string nome)
        {
            try
            {
                 var enderecos = await _enderecoPersist.GetAllEnderecosByNomeAsync(nome);
                 if (enderecos == null) return null;

                 return enderecos;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);  
            }
        }

        public async Task<Endereco> GetEnderecoByIdAsync(int id)
        {
            try
            {
                 var endereco = await _enderecoPersist.GetEnderecoByIdAsync(id);
                 if (endereco == null) return null;

                 return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                  
            }
        }

        
    }
}