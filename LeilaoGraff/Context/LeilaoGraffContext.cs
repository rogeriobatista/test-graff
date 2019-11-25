using LeilaoGraff.Models;
using Microsoft.EntityFrameworkCore;

namespace LeilaoGraff.Context
{
    public class LeilaoGraffContext : DbContext
    {
        public LeilaoGraffContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().Ignore(x => x.CascadeMode);
            modelBuilder.Entity<Produto>()
                .HasMany(x => x.Lances)
                .WithOne(x => x.Produto)
                .HasForeignKey(x => x.ProdutoId);

            modelBuilder.Entity<Pessoa>().Ignore(x => x.CascadeMode);
            modelBuilder.Entity<Pessoa>()
                .HasMany(x => x.Lances)
                .WithOne(x => x.Pessoa)
                .HasForeignKey(x => x.PessoaId);

            modelBuilder.Entity<Lance>().Ignore(x => x.CascadeMode);
        }
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Lance> Lances { get; set; }
    }
}
