using FluentValidation;

namespace ecommerce.DTOs.Request
{
    public class CardRequest
    {
        public int IdCard { get; set; }
        public string Email { get; set; }
        public string CardName { get; set; }
        public string UsernameCard { get; set; }
        public string NumberCard { get; set; }
        public string ExpireDate { get; set; }
        public bool InUse { get; set; }
    }

    internal class CardValidation : AbstractValidator<CardRequest>
    {
        public CardValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.CardName).NotEmpty();
            RuleFor(x => x.UsernameCard).NotEmpty();
            RuleFor(x => x.NumberCard).NotEmpty();
            RuleFor(x => x.ExpireDate).NotEmpty();
        }
    }
}
