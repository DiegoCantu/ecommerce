using FluentValidation;

namespace ecommerce.DTOs.Request
{
    public class AddressRequest
    {
        public int IdAddress { get; set; }
        public string Email { get; set; }
        public string BuyerName { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Indications { get; set; }
        public bool InUse { get; set; }
    }

    internal class AddressValidation : AbstractValidator<AddressRequest>
    {
        public AddressValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.BuyerName).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Suburb).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.PostalCode).NotEmpty();
            RuleFor(x => x.InUse).NotEmpty();
        }
    }
}
