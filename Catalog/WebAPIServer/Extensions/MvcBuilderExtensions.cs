using Catalog.Application.Configurations;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Catalog.WebAPIServer.Extensions
{
    internal static class MvcBuilderExtensions
    {
        internal static IMvcBuilder AddValidators(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppConfiguration>());
            return builder;
        }        
    }
}