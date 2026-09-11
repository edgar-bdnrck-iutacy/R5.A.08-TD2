using R5.A._08_TD2.Models;

namespace R5.A._08_TD2.Repositories
{
    public interface IMarqueRepository
    {
        Task<IEnumerable<Marque>> GetAllAsync();
        Task<Marque?> GetByIdAsync(int id);
        Task<Marque> AddAsync(Marque marque);
        Task UpdateAsync(Marque marque);
        Task DeleteAsync(int id);
        bool Exists(int id);
    }
}