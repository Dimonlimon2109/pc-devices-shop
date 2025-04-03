using FluentValidation;
using PCDevicesShop.BLL.Models;
using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.BLL.Validators
{
    public class FilterDeviceModelValidator: AbstractValidator<FilterDeviceModel>
    {
        public FilterDeviceModelValidator() {
            RuleFor(d => d.Name)
                    .NotEmpty()
                    .WithMessage("Название товара не может быть пустым");
            RuleFor(d => d.StartPrice)
                .GreaterThan(0)
                .WithMessage("Цена товара всегда больше 0")
                .LessThanOrEqualTo(d => d.EndPrice)
                .WithMessage("Фильтр начальной цены должен быть меньше либо равен фильтру конечной цены");
            RuleFor(d => d.EndPrice)
                .GreaterThan(0)
                .WithMessage("Цена товара всегда больше 0")
                .GreaterThanOrEqualTo(d => d.StartPrice)
                .WithMessage("Фильтр конечной цены должен быть больше либо равен фильтру начальной цены");
                        RuleFor(d => d.EndPrice)
                .GreaterThan(0)
                .WithMessage("Цена товара всегда больше 0")
                .GreaterThanOrEqualTo(d => d.StartPrice)
                .WithMessage("Фильтр конечной цены должен быть больше либо равен фильтру начальной цены");
            RuleFor(d => d.Page)
                .GreaterThan(0)
                .WithMessage("Страница должна быть больше 0");
            RuleFor(d => d.PageSize)
                .GreaterThan(0)
                .WithMessage("Длина страницы должна быть больше 0");

        }
    }
}
