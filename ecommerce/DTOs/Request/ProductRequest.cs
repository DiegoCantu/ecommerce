using FluentValidation;

namespace ecommerce.DTOs.Request
{
    public class ProductRequest
    {
        public int IdProduct { get; set; }
        public int IdCategory { get; set; }
        public string Sku { get; set; }
        public string Title { get; set; }
        public string SubHeader { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public int Rating { get; set; }
        public string Img { get; set; }
        public bool ImgApproved { get; set; } = false;
    }

    internal class ProductValidation : AbstractValidator<ProductRequest>
    {
        public ProductValidation()
        {
            RuleFor(x => x.IdCategory).NotEmpty();
            RuleFor(x => x.Sku).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.SubHeader).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.Rating).NotEmpty();
            RuleFor(x => x.Img).NotEmpty();
        }
    }
}
