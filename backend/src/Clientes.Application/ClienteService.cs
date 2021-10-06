using System;
using System.Threading.Tasks;
using Clientes.Application.Interfaces;
using Clientes.Domain.Models;
using Clientes.Persistence.Interfaces;

namespace Clientes.Application
{
    public class ClienteService : IClienteService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IClientePersist _clientePersist;

        public ClienteService(IGeralPersist geralPersist, IClientePersist clientePersist)
        {
            _clientePersist = clientePersist;
            _geralPersist = geralPersist;
        }
        public async Task<Cliente> AddCliente(Cliente model)
        {
            try
            {
                _geralPersist.Add<Cliente>(model);
                if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _clientePersist.GetClienteByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> UpdateCliente(int clienteId, Cliente model)
        {
            try
            {
                var cliente = await _clientePersist.GetClienteByIdAsync(clienteId);
                if (cliente == null) return null; 

                model.Id = cliente.Id;
                

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync()) 
                {
                    return await _clientePersist.GetClienteByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCliente(int clienteId)
        {
             try
            {
                var cliente = await _clientePersist.GetClienteByIdAsync(clienteId);
                if (cliente == null) return false; 

                _geralPersist.Delete<Cliente>(cliente);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente[]> GetAllClientesAsync()
        {
            try
            {
                var clientes = await _clientePersist.GetAllClientesAsync();
                if (clientes == null) return null;

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente[]> GetAllClientesByNomeAsync(string nome)
        {
            try
            {
                var clientes = await _clientePersist.GetAllClientesByNomeAsync(nome);
                if (clientes == null) return null;

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> GetClienteByIdAsync(int ClienteId)
        {
            try
            {
                var cliente = await _clientePersist.GetClienteByIdAsync(ClienteId);
                if (cliente == null) return null;

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}