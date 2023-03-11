using TN.Modules.Building.API;
using TN.Modules.Configuration.API;
using TN.Modules.Identity.API;
using TN.Modules.Logger.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigurationModule();
builder.Services.AddIdentityModule();
builder.Services.AddLoggerModule();
builder.Services.AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseConfigurationModule();
app.UseIdentityModule();
app.UseLoggerModule();

app.MapControllers();

app.Run();
