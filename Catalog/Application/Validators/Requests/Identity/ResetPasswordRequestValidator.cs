using Catalog.Application.Requests.Identity;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.Application.Validators.Requests.Identity
{
    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidator(IStringLocalizer<ResetPasswordRequestValidator> localizer)
        {
            RuleFor(request => request.Email)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["El correo electrónico es requerido"])
                .EmailAddress().WithMessage(x => localizer["El correo electrónico no es correcto"]);
            RuleFor(request => request.Password)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["¡Se requiere contraseña!"])
                .MinimumLength(8).WithMessage(localizer["La contraseña debe tener al menos una longitud de 8"])
                .Matches(@"[A-Z]").WithMessage(localizer["La contraseña debe contener al menos una letra mayúscula"])
                .Matches(@"[a-z]").WithMessage(localizer["La contraseña debe contener al menos una letra minúscula"])
                .Matches(@"[0-9]").WithMessage(localizer["La contraseña debe contener al menos un número"]);
            RuleFor(request => request.ConfirmPassword)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["¡Se requiere confirmación de contraseña!"])
                .Equal(request => request.Password).WithMessage(x => localizer["Las contraseñas no coinciden"]);
            RuleFor(request => request.Token)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["El Token es requerido."]);
        }
    }
}
