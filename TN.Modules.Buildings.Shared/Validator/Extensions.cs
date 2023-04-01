using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.Validator
{
    public static class Extensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services, Type type)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(type);

            return services;
        }
    }
}
