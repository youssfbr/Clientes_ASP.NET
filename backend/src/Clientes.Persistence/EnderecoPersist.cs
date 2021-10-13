using System.Linq;
using System.Threading.Tasks;
using Clientes.Domain.Models;
using Clientes.Persistence.Context;
using Clientes.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Persistence
{
    public class EnderecoPersist //: IEnderecoPersist
    {
        private readonly DataContext _context;
        public EnderecoPersist(DataContext context)
        {
            _context = context;

        }/*
        public async Task<Endereco[]> GetAllEnderecosAsync()
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(e => e.Bairro)
                .Include(e => e.Cidade);
               // .Include(e => e.Cliente);

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id);


            return await query.ToArrayAsync();
        }

        public async Task<Endereco[]> GetAllEnderecosByNome(string nome)
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(e => e.Bairro)
                .Include(e => e.Cidade);
                //.Include(e => e.Cliente);

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id)
                         .Where(e => e.Nome.ToLower()
                         .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Endereco> GetEnderecoById(int id)
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(e => e.Bairro)
                .Include(e => e.Cidade);
                //.Include(e => e.Cliente);

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id)
                         .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
*/
    }
}