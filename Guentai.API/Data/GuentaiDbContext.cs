using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guentai.API.Data
{
    public class GuentaiDbContext : DbContext
    {
        public GuentaiDbContext(DbContextOptions<GuentaiDbContext> options) : base(options) {}

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<ClienteMesa> ClientesMesas{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>()
                .Property(p => p.Descricao)
                   .HasMaxLength(80);

            modelBuilder.Entity<Perfil>()
              .Property(p => p.Descricao)
                 .HasPrecision(10, 2);

            modelBuilder.Entity<Perfil>()
                .HasData(
                new Perfil { Id = 1, Descricao = "ADM"});
        }

    }
}
