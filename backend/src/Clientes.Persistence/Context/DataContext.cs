using Clientes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TelefoneTipo> TelefonesTipos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EquipamentoTipo> EquipamentosTipos { get; set; }
        public DbSet<EquipamentoMarca> EquipamentosMarcas { get; set; }        
        public DbSet<Equipamento> Equipamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Telefones)
                .WithOne(t => t.Cliente)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Endereco)
                .WithOne(t => t.Cliente)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);    
            modelBuilder.Entity<Cliente>().Property(c => c.Nome).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Email).HasMaxLength(60);
            modelBuilder.Entity<Cliente>().Property(c => c.CPF).HasMaxLength(11);
            modelBuilder.Entity<Cliente>().Property(c => c.Observacao).HasMaxLength(255);

            modelBuilder.Entity<TelefoneTipo>().ToTable("TelefoneTipo");
            modelBuilder.Entity<TelefoneTipo>().HasKey(t => t.Id);    
            modelBuilder.Entity<TelefoneTipo>().Property(t => t.Tipo).HasMaxLength(11).IsRequired();
            
            modelBuilder.Entity<Telefone>().ToTable("Telefone");
            modelBuilder.Entity<Telefone>().HasKey(t => t.Id);    
            modelBuilder.Entity<Telefone>().Property(t => t.TelefoneTipoId).HasDefaultValue(1);
            modelBuilder.Entity<Telefone>().Property(t => t.Numero).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Telefone>().HasOne(t => t.Cliente);

            modelBuilder.Entity<Bairro>().ToTable("Bairro");
            modelBuilder.Entity<Bairro>().HasKey(b => b.Id);    
            modelBuilder.Entity<Bairro>().Property(b => b.Nome).HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Cidade>().ToTable("Cidade");
            modelBuilder.Entity<Cidade>().HasKey(c => c.Id);    
            modelBuilder.Entity<Cidade>().Property(c => c.Nome).HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Endereco>().HasKey(e => e.Id);    
            modelBuilder.Entity<Endereco>().Property(e => e.CEP).HasMaxLength(11);
            modelBuilder.Entity<Endereco>().Property(e => e.Logradouro).HasMaxLength(11);
            modelBuilder.Entity<Endereco>().Property(e => e.Nome).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Numero).HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Endereco>().Property(e => e.Complemento).HasMaxLength(60);
            modelBuilder.Entity<Endereco>().Property(e => e.BairroId).HasDefaultValue(1);
            modelBuilder.Entity<Endereco>().Property(e => e.CidadeId).HasDefaultValue(1);
            modelBuilder.Entity<Endereco>().HasOne(e => e.Bairro);
            modelBuilder.Entity<Endereco>().HasOne(e => e.Cidade);
            modelBuilder.Entity<Endereco>().HasOne(e => e.Cliente);

            modelBuilder.Entity<EquipamentoTipo>().ToTable("EquipamentoTipo");
            modelBuilder.Entity<EquipamentoTipo>().HasKey(et => et.Id);    
            modelBuilder.Entity<EquipamentoTipo>().Property(et => et.Tipo).HasMaxLength(20).IsRequired();

            modelBuilder.Entity<EquipamentoMarca>().ToTable("EquipamentoMarca");
            modelBuilder.Entity<EquipamentoMarca>().HasKey(et => et.Id);    
            modelBuilder.Entity<EquipamentoMarca>().Property(et => et.Marca).HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Equipamento>().ToTable("Equipamento");
            modelBuilder.Entity<Equipamento>().HasKey(e => e.Id);    
            modelBuilder.Entity<Equipamento>().Property(e => e.EquipamentoTipoId).HasDefaultValue(1);
            modelBuilder.Entity<Equipamento>().HasOne(e => e.EquipamentoTipo);
            modelBuilder.Entity<Equipamento>().HasOne(e => e.EquipamentoMarca);
            modelBuilder.Entity<Equipamento>().Property(e => e.Modelo).HasMaxLength(20);
            modelBuilder.Entity<Equipamento>().Property(e => e.NumeroSerie).HasMaxLength(30);
            modelBuilder.Entity<Equipamento>().Property(e => e.ServiceTag).HasMaxLength(30);
            modelBuilder.Entity<Equipamento>().Property(e => e.Codigo).HasMaxLength(30);
            modelBuilder.Entity<Equipamento>().HasOne(e => e.Cliente);
            modelBuilder.Entity<Equipamento>().Property(e => e.Observacao).HasMaxLength(255);
        }
    }
}