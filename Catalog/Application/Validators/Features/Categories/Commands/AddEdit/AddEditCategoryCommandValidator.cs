using Catalog.Application.Features.Categories.Commands.AddEdit;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.Application.Validators.Features.Categories.Commands.AddEdit
{
    public class AddEditCategoryCommandValidator : AbstractValidator<AddEditCategoryCommand>
    {
        public AddEditCategoryCommandValidator(IStringLocalizer<AddEditCategoryCommandValidator> localizer)
        {
            RuleFor(request => request.Name)
               .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["El nombre de la categoría es obligatoria"]);
            RuleFor(request => request.Description)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["La descripción es obligatoria"]);
        }
    }
}
