using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TN.Client.Mobile.BlazorWasm;
using TN.Client.Services.Remittance;
using TN.Client.Services.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddRemittanceServices();
builder.Services.AddWebSharedServices(options => {
    options.ApplicationName = "Soriana";
    options.Language = "es";
    options.Culture = "MX";
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
