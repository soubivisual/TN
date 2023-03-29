using TN.Modules.Buildings.Shared;
using TN.Modules.Notifications.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNotificationsModule();
builder.Services.AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseNotificationsModule();

app.MapControllers();

app.Run();