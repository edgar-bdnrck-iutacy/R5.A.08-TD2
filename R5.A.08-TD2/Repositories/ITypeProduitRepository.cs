using R5.A._08_TD2.Models;

namespace R5.A._08_TD2.Repositories
{
    public interface ITypeProduitRepository
    {
        Task<IEnumerable<TypeProduit>> GetAllAsync();
        Task<TypeProduit?> GetByIdAsync(int id);
        Task<TypeProduit> AddAsync(TypeProduit typeProduit);
        Task UpdateAsync(TypeProduit typeProduit);
        Task DeleteAsync(int id);
        bool Exists(int id);
    }
}