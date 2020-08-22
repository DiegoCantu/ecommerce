using FluentValidation;

namespace ecommerce.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    internal class LoginValidation : AbstractValidator<Login>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
