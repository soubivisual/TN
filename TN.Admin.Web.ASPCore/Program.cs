using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using static TN.Admin.Web.ASPCore.Miscellaneous.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler(options =>
	{
		options.Run(async context => 
		{
			var coreProcessId = Guid.NewGuid();
			var ex = context.Features.Get<IExceptionHandlerFeature>();

			if (ex != null)
			{
				//Log.ApplicationLog(LogType.Error, coreProcessId, ex.Error);

				if (ex.Error.InnerException != null)
				{
					var otherException = ex.Error.InnerException;

					while (true)
					{
						//Log.ApplicationLog(LogType.Error, coreProcessId, otherException.Message);

						if (otherException.InnerException != null)
							otherException = otherException.InnerException;
						else
							break;
					}
				}
			}

			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Response.ContentType = "text/html";
			context.Response.Redirect($"/Miscellaneous/Error?statusCode=500&coreProcessId={coreProcessId}");

			await Task.CompletedTask;
		});
	});
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();

}
else
{
	app.UseDeveloperExceptionPage();
}

	

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: RouteName.Home,
	pattern: "Home",
	defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: RouteName.NotFound,
	pattern: "Miscellaneous/Error/statusCode=404",
	defaults: new { controller = "Miscellaneous", action = "Error", statusCode = 404 });

app.Run();
