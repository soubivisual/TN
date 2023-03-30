using TN.Modules.Buildings.Shared;
using TN.Modules.Configurations.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigurationsModule();
builder.Services.AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseConfigurationsModule();

app.MapControllers();

app.Run();
