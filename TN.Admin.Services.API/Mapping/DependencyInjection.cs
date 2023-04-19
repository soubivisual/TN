using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Reflection;

namespace TN.Admin.Services.API.Mapping
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddMappings(this IServiceCollection services)
		{
			var config = TypeAdapterConfig.GlobalSettings;
			config.Scan(Assembly.GetExecutingAssembly());

			services.AddSingleton(config);
			services.AddScoped<IMapper, ServiceMapper>();
			return services;
		}
	}
}
