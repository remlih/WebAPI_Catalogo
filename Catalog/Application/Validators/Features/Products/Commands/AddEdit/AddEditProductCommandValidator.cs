using Catalog.Application.Features.Products.Commands.AddEdit;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.Application.Validators.Features.Products.Commands.AddEdit
{
    public class AddEditProductCommandValidator : AbstractValidator<AddEditProductCommand>
    {
        public AddEditProductCommandValidator(IStringLocalizer<AddEditProductCommandValidator> localizer)
        {
            RuleFor(request => request.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["El nombre es requerido."]);
            RuleFor(request => request.Barcode)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["El código de barras es requerido."]);
            RuleFor(request => request.Description)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["La descripción es requerida."]);
            RuleFor(request => request.BrandId)
                .GreaterThan(0).WithMessage(x => localizer["La marca es requerida."]);
            RuleFor(request => request.CategoryId)
                .GreaterThan(0).WithMessage(x => localizer["La categoría es requerida."]);
            RuleFor(request => request.Rate)
                .GreaterThan(0).WithMessage(x => localizer["El precio debe ser mayor a 0"]);
        }
    }
}