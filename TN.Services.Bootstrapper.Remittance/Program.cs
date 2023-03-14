using TN.Modules.Buildings.API;
using TN.Modules.Remittances.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRemittancesModule();
builder.Services.AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseRemittancesModule();

app.MapControllers();

app.Run();
