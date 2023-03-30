using TN.Modules.Buildings.Shared;
using TN.Modules.Loggers.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLoggersModule();
builder.Services.AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseLoggersModule();

app.MapControllers();

app.Run();