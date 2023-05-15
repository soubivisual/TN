using Microsoft.Extensions.Options;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
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
            var culture = string.IsNullOrEmpty(options?.Value?.Culture) ? options?.Value?.Language : $"{options?.Value?.Language}-{options?.Value?.Culture}"; 
            SetSpecificCulture(culture);
        }
        
        public string GetResourceValue(string key,[CallerFilePathAttribute]string @namespace = null)
        {
            var method = new StackTrace().GetFrame(1).GetMethod();
            //string className = method.DeclaringType.Name; 
            //string namespaceName = method.DeclaringType.Namespace;
            //string namespaceNameBase = method.DeclaringType.BaseType.ToString();

            var assembly = Assembly.GetCallingAssembly();
            var baseName = method.DeclaringType.BaseType.ToString();

            _resourceManager = new ResourceManager(baseName, assembly);
            return _resourceManager.GetString(key, _culture) ?? "Resource Not Found!";
        }

        public void SetSpecificCulture(string culture) => _culture = CultureInfo.CreateSpecificCulture(culture ?? "en");
        
    }
}
