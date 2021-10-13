using System.Linq;
using System.Threading.Tasks;
using Clientes.Domain.Models;
using Clientes.Persistence.Context;
using Clientes.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Persistence
{
    public class ClientePersist : IClientePersist
    {
        private readonly DataContext _context;

        public ClientePersist(DataContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }   

        public async Task<Cliente[]> GetAllClientesAsync()
        {
            IQueryable<Cliente> query = _context.Clientes
                .Include(c => c.Telefones).ThenInclude(t => t.TelefoneTipo)
                .Include(c => c.Endereco)
                .Include(c => c.Endereco.Bairro)
                .Include(c => c.Endereco.Cidade);

            query = query
                        .AsNoTracking()
                        .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente[]> GetAllClientesByNomeAsync(string nome)
        {
            IQueryable<Cliente> query = _context.Clientes
                .Include(c => c.Telefones).ThenInclude(t => t.TelefoneTipo)
                .Include(c => c.Endereco)
                .Include(c => c.Endereco.Bairro)
                .Include(c => c.Endereco.Cidade);

            query = query.AsNoTracking()
                            .OrderBy(c => c.Id)
                            .Where(c => c.Nome.ToLower()
                            .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        
        public async Task<Cliente> GetClienteByIdAsync(int ClienteId)
        {
            IQueryable<Cliente> query = _context.Clientes
                .Include(c => c.Telefones)
                .Include(c => c.Telefones).ThenInclude(t => t.TelefoneTipo)
                .Include(c => c.Endereco)
                .Include(c => c.Endereco.Bairro)
                .Include(c => c.Endereco.Cidade);

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id)
                         .Where(c => c.Id == ClienteId);

            return await query.FirstOrDefaultAsync();
        }

    }
}