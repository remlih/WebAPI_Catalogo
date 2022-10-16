using Catalog.Application.Requests.Identity;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.Application.Validators.Requests.Identity
{
    public class RoleRequestValidator : AbstractValidator<RoleRequest>
    {
        public RoleRequestValidator(IStringLocalizer<RoleRequestValidator> localizer)
        {
            RuleFor(request => request.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["El nombre es requerido."]);
        }
    }
}
