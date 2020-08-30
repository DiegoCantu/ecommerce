using FluentValidation;

namespace ecommerce.DTOs.Request
{
    public class UserRequest
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    internal class UserValidation : AbstractValidator<UserRequest>
    {
        public UserValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
