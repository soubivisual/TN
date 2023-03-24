using TN.Modules.Buildings.Shared;
using TN.Modules.Configurations.API;
using TN.Modules.IdentitiesAPI;
using TN.Modules.Loggers.API;
using TN.Modules.Notifications.API;
using TN.Modules.Remittances.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigurationsModule();
builder.Services.AddIdentitiesModule();
builder.Services.AddLoggersModule();
builder.Services.AddNotificationsModule();
builder.Services.AddRemittancesModule();
builder.Services.AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseConfigurationsModule();
app.UseIdentitiesModule();
app.UseLoggersModule();
app.UseNotificationsModule();
app.UseRemittancesModule();

app.MapControllers();

app.Run();
