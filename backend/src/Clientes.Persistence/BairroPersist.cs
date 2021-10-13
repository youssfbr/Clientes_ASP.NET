using System.Linq;
using System.Threading.Tasks;
using Clientes.Domain.Models;
using Clientes.Persistence.Context;
using Clientes.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Persistence
{
    public class BairroPersist : IBairroPersist
    {
        private readonly DataContext _context;

        public BairroPersist(DataContext context)
        {
            _context = context;
        }

        public async Task<Bairro[]> GetAllBairrosAsync()
        {
            IQueryable<Bairro> query = _context.Bairros;

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Bairro[]> GetAllBairrosByNomeAsync(string nome)
        {
            IQueryable<Bairro> query = _context.Bairros;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.Nome.ToLower()
                         .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Bairro> GetBairroByIdAsync(int BairroId)
        {
            IQueryable<Bairro> query = _context.Bairros;

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id)
                         .Where(c => c.Id == BairroId);

            return await query.FirstOrDefaultAsync();
        }

    }
}