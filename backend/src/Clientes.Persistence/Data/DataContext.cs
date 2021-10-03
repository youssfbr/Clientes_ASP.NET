using Clientes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Persistence.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }        
    }
}