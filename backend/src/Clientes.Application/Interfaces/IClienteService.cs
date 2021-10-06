using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Domain.Models;

namespace Clientes.Application.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> AddCliente(Cliente model);        
        Task<Cliente> UpdateCliente(int id, Cliente model);
        Task<bool> DeleteCliente(int id);

        Task<Cliente[]> GetAllClientesAsync();
        Task<Cliente[]> GetAllClientesByNomeAsync(string nome);
        Task<Cliente> GetClienteByIdAsync(int id);     
    }
}