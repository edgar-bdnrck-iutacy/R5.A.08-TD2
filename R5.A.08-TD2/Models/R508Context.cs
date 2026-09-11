using Microsoft.EntityFrameworkCore;

namespace R5.A._08_TD2.Models
{
    public class R508Context : DbContext
    {
        public R508Context(DbContextOptions<R508Context> options)
            : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<TypeProduit> TypesProduit { get; set; }
    }
}
