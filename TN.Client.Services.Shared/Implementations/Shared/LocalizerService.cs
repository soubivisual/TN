using Microsoft.Extensions.Options;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TN.Client.Services.Shared.Configurations;
using TN.Client.Services.Shared.Interfaces;
using static Microsoft.Maui.Authentication.AppleSignInAuthenticator;

namespace TN.Client.Services.Shared.Implementations.Shared
{
    public class LocalizerService : ILocalizerService
    {
        private ResourceManager _resourceManager;
        private CultureInfo _culture;

        public LocalizerService(IOptions<ApplicationServiceOptions> options)
        {
            SetSpecificCulture(options?.Value?.Culture);
        }
        public string GetResourceValue(string key)
        {
            var assembly = Assembly.GetCallingAssembly();
            //TODO: 
            var baseName = "TN.Client.Components.Authentication.Resources.Pages.FirstPage";

            _resourceManager = new ResourceManager(baseName, assembly);
            return _resourceManager.GetString(key, _culture) ?? "Resource Not Found!";
        }

        public void SetSpecificCulture(string culture) => _culture = CultureInfo.CreateSpecificCulture(culture ?? "en");
        
    }
}
