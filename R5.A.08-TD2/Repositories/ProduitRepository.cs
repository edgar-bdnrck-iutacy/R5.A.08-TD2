using Microsoft.EntityFrameworkCore;
using R5.A._08_TD2.Models;

namespace R5.A._08_TD2.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly R508Context _context;

        public ProduitRepository(R508Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produit>> GetAllAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task<Produit?> GetByIdAsync(int id)
        {
            return await _context.Produits.FindAsync(id);
        }

        public async Task<Produit> AddAsync(Produit produit)
        {
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();
            return produit;
        }

        public async Task UpdateAsync(Produit produit)
        {
            _context.Entry(produit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produit = await _context.Produits.FindAsync(id);

            if (produit != null)
            {
                _context.Produits.Remove(produit);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(int id)
        {
            return _context.Produits.Any(p => p.IdProduit == id);
        }
    }
}