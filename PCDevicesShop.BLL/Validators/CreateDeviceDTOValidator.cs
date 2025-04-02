using FluentValidation;
using PCDevicesShop.BLL.DTO;
using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.BLL.Validators
{
    public class CreateDeviceDTOValidator:AbstractValidator<CreateDeviceDTO>
    {
        public CreateDeviceDTOValidator() {
            RuleFor(d => d.Name)
                    .NotEmpty()
                    .WithMessage("Название товара не может быть пустым");
            RuleFor(d => d.Description)
                .NotEmpty()
                .WithMessage("Описание товара не может быть пустым");
            RuleFor(d => d.Price)
                .GreaterThan(0)
                .WithMessage("Цена товара всегда больше 0");
            RuleFor(d => d.StockQuantity)
                .GreaterThan((byte)0)
                .LessThan((byte)100)
                .WithMessage("Скидка может быть в диапазоне от 0 до 100");
            RuleFor(d => d.Category)
                .NotEqual(DeviceCategories.None)
                .WithMessage("Должна быть строгая категория");
        }
    }
}
