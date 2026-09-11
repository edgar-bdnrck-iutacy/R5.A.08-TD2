using Microsoft.EntityFrameworkCore;
using R5.A._08_TD2.Models;

namespace R5.A._08_TD2.Repositories
{
    public class MarqueRepository : IMarqueRepository
    {
        private readonly R508Context _context;

        public MarqueRepository(R508Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marque>> GetAllAsync()
        {
            return await _context.Marques.ToListAsync();
        }

        public async Task<Marque?> GetByIdAsync(int id)
        {
            return await _context.Marques.FindAsync(id);
        }

        public async Task<Marque> AddAsync(Marque marque)
        {
            _context.Marques.Add(marque);
            await _context.SaveChangesAsync();
            return marque;
        }

        public async Task UpdateAsync(Marque marque)
        {
            _context.Entry(marque).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var marque = await _context.Marques.FindAsync(id);

            if (marque != null)
            {
                _context.Marques.Remove(marque);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(int id)
        {
            return _context.Marques.Any(m => m.IdMarque == id);
        }
    }
}