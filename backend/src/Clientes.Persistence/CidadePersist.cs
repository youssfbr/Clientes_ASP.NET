using System.Linq;
using System.Threading.Tasks;
using Clientes.Domain.Models;
using Clientes.Persistence.Context;
using Clientes.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Persistence
{
    public class CidadePersist : ICidadePersist
    {
        private readonly DataContext _context;

        public CidadePersist(DataContext context)
        {
            _context = context;
        }

        public async Task<Cidade[]> GetAllCidadesAsync()
        {
            IQueryable<Cidade> query = _context.Cidades;

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Cidade[]> GetAllCidadesByNome(string nome)
        {
            IQueryable<Cidade> query = _context.Cidades;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.Nome.ToLower()
                         .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Cidade> GetCidadeById(int CidadeId)
        {
            IQueryable<Cidade> query = _context.Cidades;

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id)
                         .Where(c => c.Id == CidadeId);

            return await query.FirstOrDefaultAsync();
        }  

    }
}