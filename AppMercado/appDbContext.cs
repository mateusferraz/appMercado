using AppMercado.Models;
using Microsoft.EntityFrameworkCore;

namespace AppMercado
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(t => t.id);
            modelBuilder.Entity<Pedido>().HasKey(t => t.idPedido);
            modelBuilder.Entity<Pedido>().HasMany(t => t.itens).WithOne(t => t.pedido);
            modelBuilder.Entity<Pedido>().HasOne(t => t.pessoa).WithOne(t => t.pedido)
                .HasForeignKey<Pessoa>(t => t.idPessoa)
                .IsRequired();


            modelBuilder.Entity<ItemPedido>().HasKey(t => t.idItem);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.produto);

            modelBuilder.Entity<Pessoa>().HasKey(t => t.idPessoa);
            modelBuilder.Entity<Pessoa>().HasOne(t => t.pedido);

        }

        public DbSet<AppMercado.Models.Pedido> Pedido { get; set; }

        //public virtual DbSet<Produto> Produtos { get; set; }
    }

}
