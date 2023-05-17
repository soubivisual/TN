using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TN.Client.Services.Shared.Interfaces
{
    public interface ILocalizerService
    {
        void SetSpecificCulture(string culture);
        string GetResourceValue(string key, [CallerFilePathAttribute] string @namespace = null);
    }
}
