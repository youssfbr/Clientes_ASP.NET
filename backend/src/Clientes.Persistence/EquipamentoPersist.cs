using System.Linq;
using System.Threading.Tasks;
using Clientes.Domain.Models;
using Clientes.Persistence.Context;
using Clientes.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Persistence
{
    public class EquipamentoPersist : IEquipamentoPersist
    {
        private readonly DataContext _context;

        public EquipamentoPersist(DataContext context)
        {
            _context = context;
        }
        public async Task<Equipamento[]> GetAllEquipamentosAsync()
        {
            IQueryable<Equipamento> query = _context.Equipamentos
                .Include(e => e.EquipamentoTipo)
                .Include(e => e.EquipamentoMarca)
                .Include(e => e.Cliente)
                .ThenInclude(e => e.Telefones)
                .ThenInclude(e => e.TelefoneTipo);

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Equipamento[]> GetAllEquipamentosByModeloAsync(string modelo)
        {
            IQueryable<Equipamento> query = _context.Equipamentos;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.Modelo.ToLower()
                         .Contains(modelo.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Equipamento> GetEquipamentoByNumeroSerieAsync(string numeroSerie)
        {
            IQueryable<Equipamento> query = _context.Equipamentos;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id)
                         .Where(c => c.NumeroSerie.ToLower()
                         .Contains(numeroSerie.ToLower()));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Equipamento> GetEquipamentoByIdAsync(int EquipamentoId)
        {
               IQueryable<Equipamento> query = _context.Equipamentos;

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id)
                         .Where(c => c.Id == EquipamentoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}