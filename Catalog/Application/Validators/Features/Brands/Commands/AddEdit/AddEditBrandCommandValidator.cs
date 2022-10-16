using Catalog.Application.Features.Brands.Commands.AddEdit;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.Application.Validators.Features.Brands.Commands.AddEdit
{
    public class AddEditBrandCommandValidator : AbstractValidator<AddEditBrandCommand>
    {
        public AddEditBrandCommandValidator(IStringLocalizer<AddEditBrandCommandValidator> localizer)
        {
            RuleFor(request => request.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["El nombre es requerido."]);
            RuleFor(request => request.Description)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["La descripción es requerida."]);            
        }
    }
}