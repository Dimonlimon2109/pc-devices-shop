using FluentValidation;
using PCDevicesShop.BLL.DTO;
namespace PCDevicesShop.BLL.Validators
{
    public class LoginDTOValidator:AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator() {
            RuleFor(l => l.UserName)
                .MinimumLength(3)
                .WithMessage("Длина имени пользователя должна составлять от 3 до 50 символов")
                .MaximumLength(50)
                .WithMessage("Длина имени пользователя должна составлять от 3 до 50 символов");

            RuleFor(l => l.Password)
                .MinimumLength(8)
                .WithMessage("Длина пароля должна составлть от 8 до 30 символов")
                .MaximumLength(30)
                .WithMessage("Длина пароля должна составлть от 8 до 30 символов")
                .Matches(@"^[A-Za-z\d]*$");

        }
    }
}
