using FluentValidation;

namespace ecommerce.DTOs.Request
{
    public class CategoryRequest
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
    }

    internal class CategoryValidation : AbstractValidator<CategoryRequest>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
