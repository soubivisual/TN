using TN.Modules.Building.API;
using TN.Modules.Logger.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLoggerModule();
builder.Services.AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseLoggerModule();

app.MapControllers();

app.Run();
