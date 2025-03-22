using Microsoft.EntityFrameworkCore;
using GeeckoCadastros.Models;

namespace GeeckoCadastros.BancoDados
{
   public class GeeckoCadastrosContext(DbContextOptions<GeeckoCadastrosContext> options) : DbContext(options) //Nos lugares que constam "GeeckoCadastrosContext", estavam o "AppDbContext", troquei e deu certo a conexão com o BD
    {
        public DbSet<Produtos> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produtos>(entity =>
        {
            entity.HasKey(e => e.Cod_Prod);
            entity.Property(e => e.CodigoBarras).IsRequired();
            entity.Property(e => e.NomeProd).IsRequired();
            entity.Property(e => e.Categoria).IsRequired();
            entity.Property(e => e.Fabricante).IsRequired();
            entity.Property(e => e.Quantidade).IsRequired();
            entity.Property(e => e.ValorProd).IsRequired();
        });
        }
    }
}
