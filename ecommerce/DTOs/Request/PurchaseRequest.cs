using FluentValidation;

namespace ecommerce.DTOs.Request
{
    public class PurchaseRequest
    {
        public int IdPurchase { get; set; }
        public string Email { get; set; }
        public int IdCart { get; set; }
    }

    internal class PurchaseValidation : AbstractValidator<PurchaseRequest>
    {
        public PurchaseValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.IdCart).NotEmpty();
        }
    }
}
