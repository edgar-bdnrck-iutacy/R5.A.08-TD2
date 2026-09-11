using System.ComponentModel.DataAnnotations;

namespace R5.A._08_TD2.Models
{
    public class TypeProduit
    {
        [Key]
        public int IdTypeProduit { get; set; }

        public string NomTypeProduit { get; set; } = null!;

        public ICollection<Produit> Produits { get; set; } = new List<Produit>();
    }
}
