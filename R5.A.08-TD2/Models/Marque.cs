using System.ComponentModel.DataAnnotations;

namespace R5.A._08_TD2.Models
{
    public class Marque
    {
        [Key]
        public int IdMarque { get; set; }

        public string NomMarque { get; set; } = null!;

        public ICollection<Produit> Produits { get; set; } = new List<Produit>();
    }
}
