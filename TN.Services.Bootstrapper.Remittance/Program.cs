using TN.Modules.Buildings.API;
using TN.Modules.Loggers.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLoggerModule();
builder.Services.AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseLoggerModule();

app.MapControllers();

app.Run();
