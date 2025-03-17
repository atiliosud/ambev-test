using AmbevTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmbevTest.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Revenda> Revendas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
    }

}
