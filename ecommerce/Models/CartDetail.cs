using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class CartDetail
    {
        //Primary Key Auto-Increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCartDetail { get; set; }
        //Foreign key for Cart
        public int IdCart { get; set; }
        public Cart Cart { get; set; }
        //Foreign key for Product
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        // Columns
        public int Quantity { get; set; }
    }

    internal class CartDetailValidation : AbstractValidator<CartDetail>
    {
        public CartDetailValidation()
        {
            RuleFor(x => x.IdCart).NotEmpty();
            RuleFor(x => x.IdProduct).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
        }
    }
}
