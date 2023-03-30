using TN.Modules.Buildings.Shared;
using TN.Modules.Identities.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentitiesModule();
builder.Services.AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseIdentitiesModule();

app.MapControllers();

app.Run();
