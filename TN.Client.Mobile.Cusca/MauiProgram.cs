using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TN.Client.Services.Remittance;
using TN.Client.Services.Shared;

namespace TN.Client.Mobile.Cusca
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddRemittanceServices();
            builder.Services.AddMobileSharedServices(options => {
                options.ApplicationName = "Cusca";
                options.Language = "es";
                options.Culture = "SV";
            });

            builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddHttpClient<HttpClient>("TN.Client.Mobile.API", client => client.BaseAddress = new Uri("127.0.0.1"));
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TN.Client.Mobile.API"));

            return builder.Build();
        }
    }
}
