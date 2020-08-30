using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class CartDetail
    {
        public CartDetail()
        {
            CartDetailProductAuxiliaryNn = new HashSet<CartDetailProductAuxiliaryNn>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdCartDetail { get; set; }
        public int IdCart { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual ICollection<CartDetailProductAuxiliaryNn> CartDetailProductAuxiliaryNn { get; set; }
    }
}
