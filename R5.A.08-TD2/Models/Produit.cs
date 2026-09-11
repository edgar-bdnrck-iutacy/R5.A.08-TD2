using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R5.A._08_TD2.Models
{
    public class Produit
    {
        [Key]
        public int IdProduit { get; set; }

        public string NomProduit { get; set; } = null!;

        public string? Description { get; set; }

        public string? NomPhoto { get; set; }

        public string? UriPhoto { get; set; }

        public int IdTypeProduit { get; set; }

        public int IdMarque { get; set; }

        public int StockReel { get; set; }

        public int StockMin { get; set; }

        public int StockMax { get; set; }

        [ForeignKey(nameof(IdMarque))]
        public Marque? Marque { get; set; }

        [ForeignKey(nameof(IdTypeProduit))]
        public TypeProduit? TypeProduit { get; set; }
    }
}