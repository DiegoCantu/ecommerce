using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class CartDetailProductAuxiliaryNn
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdCartDetailProduct { get; set; }
        public int IdCartDetail { get; set; }
        public int IdProduct { get; set; }

        public virtual CartDetail CartDetail { get; set; }
        public virtual Product Product { get; set; }
    }
}
