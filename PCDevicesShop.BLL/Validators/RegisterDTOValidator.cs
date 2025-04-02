using FluentValidation;
using PCDevicesShop.BLL.DTO;

namespace PCDevicesShop.BLL.Validators
{
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(r => r.UserName)
                .MinimumLength(3)
                .WithMessage("Длина имени пользователя должна составлять от 3 до 50 символов")
                .MaximumLength(50)
                .WithMessage("Длина имени пользователя должна составлять от 3 до 50 символов");

            RuleFor(r => r.Password)
                .MinimumLength(8)
                .WithMessage("Длина пароля должна составлть от 8 до 30 символов")
                .MaximumLength(30)
                .WithMessage("Длина пароля должна составлть от 8 до 30 символов")
                .Matches(@"^[A-Za-z\d]*$");
            
            RuleFor(r => r.Email)
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Некорректный email адрес");
        }
    }
}
