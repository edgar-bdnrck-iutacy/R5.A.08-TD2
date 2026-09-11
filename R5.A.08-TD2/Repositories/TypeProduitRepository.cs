using Microsoft.EntityFrameworkCore;
using R5.A._08_TD2.Models;

namespace R5.A._08_TD2.Repositories
{
    public class TypeProduitRepository : ITypeProduitRepository
    {
        private readonly R508Context _context;

        public TypeProduitRepository(R508Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeProduit>> GetAllAsync()
        {
            return await _context.TypesProduit.ToListAsync();
        }

        public async Task<TypeProduit?> GetByIdAsync(int id)
        {
            return await _context.TypesProduit.FindAsync(id);
        }

        public async Task<TypeProduit> AddAsync(TypeProduit typeProduit)
        {
            _context.TypesProduit.Add(typeProduit);
            await _context.SaveChangesAsync();
            return typeProduit;
        }

        public async Task UpdateAsync(TypeProduit typeProduit)
        {
            _context.Entry(typeProduit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var typeProduit = await _context.TypesProduit.FindAsync(id);

            if (typeProduit != null)
            {
                _context.TypesProduit.Remove(typeProduit);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(int id)
        {
            return _context.TypesProduit.Any(t => t.IdTypeProduit == id);
        }
    }
}   