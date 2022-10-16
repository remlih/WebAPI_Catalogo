using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Catalog.Domain.Contracts;
using Catalog.Shared.Wrapper;

namespace Catalog.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddMediatR(Assembly.GetExecutingAssembly());            
        }
    }
}