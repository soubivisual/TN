using TN.Admin.Web.ASPCore.Middleware;
using static TN.Admin.Web.ASPCore.Miscellaneous.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
//	.SetMinimumLevel(LogLevel.Trace)
//	.AddConsole());

//ILogger logger = loggerFactory.CreateLogger<Program>();

var logger = LoggerFactory.Create(config =>
{
	config.AddConsole();
}).CreateLogger("Program");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.ConfigureNotFoundHandler();

	app.ConfigureExceptionHandler(logger);
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

//app.MapControllerRoute(
//	name: RouteName.NotFound,
//	pattern: "Miscellaneous/Error/statusCode=404",
//	defaults: new { controller = "Miscellaneous", action = "Error", statusCode = 404 });

app.Run();
