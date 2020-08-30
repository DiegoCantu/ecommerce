using FluentValidation;

namespace ecommerce.DTOs.Request
{
    public class CommentRequest
    {
        public int IdComment { get; set; }
        public int IdProduct { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
    }

    internal class CommentValidation : AbstractValidator<CommentRequest>
    {
        public CommentValidation()
        {
            RuleFor(x => x.IdProduct).NotEmpty();
            RuleFor(x => x.Rating).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Post).NotEmpty();
        }
    }
}
