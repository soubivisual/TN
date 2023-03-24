using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace TN.Modules.Buildings.Shared.Validator
{
    public static class Extensions
    {
        public static IServiceCollection AddValidators<T>(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<T>();

            return services;
        }
    }
}
