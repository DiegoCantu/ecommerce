using FluentValidation;
using System.Collections.Generic;

namespace ecommerce.DTOs.Request
{
    public class CartRequest
    {
        public int IdCart { get; set; }
        public string Email { get; set; }
        public bool Bought { get; set; } = false;
        public decimal Total { get; set; }
        public ICollection<CartDetailRequest> CartDetails { get; set; }
    }

    internal class CartValidation : AbstractValidator<CartRequest>
    {
        public CartValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Bought).NotEmpty();
            RuleFor(x => x.Total).NotEmpty();
            RuleFor(x => x.CartDetails).NotEmpty();
        }
    }
}
