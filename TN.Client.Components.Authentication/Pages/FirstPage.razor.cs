using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Components.Authentication.Pages
{
    public class FirstPageBase : ComponentBase
    {
        [Inject] protected ILocalizerService LocalizerService { get; set; }
    }
}
