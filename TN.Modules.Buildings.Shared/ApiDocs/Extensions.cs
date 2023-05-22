using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using TN.Modules.Buildings.Shared.Controllers;

namespace TN.Modules.Buildings.Shared.ApiDocs
{
    public static class Extensions
    {
        private static readonly string assemblyName;
        private static readonly IEnumerable<ApiVersion> apiVersions;

        static Extensions()
        {
            assemblyName = Assembly.GetEntryAssembly().GetName().Name;

            apiVersions = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(BaseController).IsAssignableFrom(x))
                .SelectMany(x => x.GetCustomAttributes(typeof(ApiVersionAttribute)))
                .OfType<ApiVersionAttribute>()
                .SelectMany(x => x.Versions)
                .Distinct();
        }

        public static IServiceCollection AddApiDocs(this IServiceCollection services)
        {
#if DEBUG
            services.AddSwaggerGen(options =>
            {
                foreach (var apiVersion in apiVersions)
                {
                    var version = $"v{apiVersion}";
                    options.SwaggerDoc(version, new OpenApiInfo { Title = assemblyName, Version = version, Description = "API Documentation" });
                }

                options.OperationFilter<RemoveVersionFromParameter>(); // se quita el parámetro que solicita la versión
                options.DocumentFilter<ReplaceVersionWithExactValueInPath>(); // Se quita el v{version} por la versión específica que está seleccionada en el combobox de la parte superior de la interfaz de swagger
                options.DocInclusionPredicate((version, desc) => // Solo mostrar los métodos disponibles para cada versión
                {
                    if (!desc.TryGetMethodInfo(out MethodInfo methodInfo))
                        return false;

                    var versions = methodInfo.DeclaringType.GetCustomAttributes(true).OfType<ApiVersionAttribute>().SelectMany(attr => attr.Versions);
                    var maps = methodInfo.GetCustomAttributes(true).OfType<MapToApiVersionAttribute>().SelectMany(attr => attr.Versions).ToArray();

                    return versions.Any(v => $"v{v}" == version) && (!maps.Any() || maps.Any(v => $"v{v}" == version));
                });
            });
#endif

            return services;
        }

        public static IApplicationBuilder UseApiDocs(this IApplicationBuilder app, Action<SwaggerUIOptions> setupAction = null)
        {
#if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = $"{assemblyName} Swagger UI";

                foreach (var apiVersion in apiVersions)
                {
                    c.SwaggerEndpoint($"/swagger/v{apiVersion}/swagger.json", $"Teledolar VISA B2B API V{apiVersion}");
                }
            });
#endif

            return app;
        }
    }
}
