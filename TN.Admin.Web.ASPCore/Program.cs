using System.Configuration;
using Auth0.AspNetCore.Authentication;
using TN.Admin.Web.ASPCore.Middleware;
using static TN.Admin.Web.ASPCore.Miscellaneous.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Cookie configuration for HTTP to support cookies with SameSite=None
builder.Services.ConfigureSameSiteNoneCookies();

// Cookie configuration for HTTPS
//  builder.Services.Configure<CookiePolicyOptions>(options =>
//  {
//     options.MinimumSameSitePolicy = SameSiteMode.None;
//  });
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"] ?? throw new SettingsPropertyNotFoundException("Auth0:Domain not configured");
    options.ClientId = builder.Configuration["Auth0:ClientId"]  ?? throw new SettingsPropertyNotFoundException("Auth0:ClientId not configured");;
});

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
if (!app.Environment.IsDevelopment())
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

app.UseAuthentication();
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
