using R5.A._08_TD2.Models;

namespace R5.A._08_TD2.Repositories
{
    public interface IProduitRepository
    {
        Task<IEnumerable<Produit>> GetAllAsync();
        Task<Produit?> GetByIdAsync(int id);
        Task<Produit> AddAsync(Produit produit);
        Task UpdateAsync(Produit produit);
        Task DeleteAsync(int id);
        bool Exists(int id);
    }
}