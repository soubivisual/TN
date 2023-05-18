using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace TN.Admin.Web.ASPCore.Middleware
{
	public static  class Extensions
	{
		public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
		{
			app.UseExceptionHandler(options =>
			{
				options.Run(async context =>
				{
					var coreProcessId = Guid.NewGuid();
					var ex = context.Features.Get<IExceptionHandlerFeature>();

					if (ex != null)
					{
						logger.LogError(ex.Error, ex?.Error?.Message, coreProcessId);
						//Log.ApplicationLog(LogType.Error, coreProcessId, ex.Error);

						if (ex?.Error.InnerException != null)
						{
							var otherException = ex.Error.InnerException;

							while (true)
							{
								logger.LogError(ex?.Error, otherException?.Message, coreProcessId);
								//Log.ApplicationLog(LogType.Error, coreProcessId, otherException.Message);

								if (otherException?.InnerException != null)
									otherException = otherException?.InnerException;
								else
									break;
							}
						}
					}

					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "text/html";
					context.Response.Redirect($"/Miscellaneous/Error500?coreProcessId={coreProcessId}");

					await Task.CompletedTask;
				});
			});
		}
		public static void ConfigureNotFoundHandler(this IApplicationBuilder app)
		{
			app.Use(async (context, next) =>
			{
				await next();
				if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
				{
					context.Request.Path = $"/Miscellaneous/Error404";
					await next();
				}
			});
		}
		public static IServiceCollection ConfigureSameSiteNoneCookies(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
                options.OnAppendCookie = cookieContext => CheckSameSite(cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext => CheckSameSite(cookieContext.CookieOptions);
            });

            return services;
        }
        private static void CheckSameSite(CookieOptions options)
        {
            if (options.SameSite == SameSiteMode.None && options.Secure == false) 
                options.SameSite = SameSiteMode.Unspecified;
            
        }
	}
}
