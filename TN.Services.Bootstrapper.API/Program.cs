using TN.Modules.Buildings.API;
using TN.Modules.Configurations.API;
using TN.Modules.IdentitiesAPI;
using TN.Modules.Loggers.API;

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
