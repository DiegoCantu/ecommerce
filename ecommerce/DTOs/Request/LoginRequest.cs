using FluentValidation;

namespace ecommerce.DTOs.Request
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    internal class LoginValidation : AbstractValidator<LoginRequest>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
