using TN.Client.Services.Remittance;
using TN.Client.Services.Shared;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddRemittanceServices();
builder.Services.AddWebSharedServices(options => {
    options.ApplicationName = "Soriana";
    options.Language = "es";
    options.Culture = "CR";  
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseWebSharedServices();
app.UseRemittanceServices();

app.Run();

