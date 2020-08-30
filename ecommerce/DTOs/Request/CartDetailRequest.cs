using FluentValidation;

namespace ecommerce.DTOs.Request
{
    public class CartDetailRequest
    {
        public int IdCartDetail { get; set; }
        public int IdCart { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
    }

    internal class CartDetailValidation : AbstractValidator<CartDetailRequest>
    {
        public CartDetailValidation()
        {
            RuleFor(x => x.IdCart).NotEmpty();
            RuleFor(x => x.IdProduct).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
        }
    }
}
