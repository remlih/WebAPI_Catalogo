﻿using Catalog.Application.Requests.Identity;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.Application.Validators.Requests.Identity
{
    public class TokenRequestValidator : AbstractValidator<TokenRequest>
    {
        public TokenRequestValidator(IStringLocalizer<TokenRequestValidator> localizer)
        {
            RuleFor(request => request.Email)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["El correo electrónico es requerido"])
                .EmailAddress().WithMessage(x => localizer["El correo electrónico no es correcto"]);
            RuleFor(request => request.Password)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["La contraseña es requedira"]);
        }
    }
}
