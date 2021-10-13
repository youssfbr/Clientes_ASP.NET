using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Domain.Models;
using Clientes.Persistence.Context;
using Clientes.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Persistence
{
    public class EquipamentoMarcaPersist : IEquipamentoMarcaPersist
    {
        private readonly DataContext _context;

        public EquipamentoMarcaPersist(DataContext context)
        {
            _context = context;
        }

        public async Task<EquipamentoMarca[]> GetAllEquipamentosMarcasAsync()
        {
            IQueryable<EquipamentoMarca> query = _context.EquipamentosMarcas;

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<EquipamentoMarca[]> GetAllEquipamentosMarcasByMarcaAsync(string marca)
        {
            IQueryable<EquipamentoMarca> query = _context.EquipamentosMarcas;                

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id)
                         .Where(e => e.Marca.ToLower()
                         .Contains(marca.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<EquipamentoMarca> GetEquipamentoMarcaByIdAsync(int id)
        {
            IQueryable<EquipamentoMarca> query = _context.EquipamentosMarcas;                

            query = query.AsNoTracking()
                         .OrderBy(e => e.Id)
                         .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}