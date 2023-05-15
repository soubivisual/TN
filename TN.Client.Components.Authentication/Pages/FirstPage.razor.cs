using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TN.Client.Services.Shared.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TN.Client.Components.Authentication.Pages
{
    public class FirstPageBase : ComponentBase
    {
        [Inject] protected ILocalizerService LocalizerService { get; set; }
        [Inject] protected IApplicationInformation ApplicationInformationService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        public bool showTopButton { get; set; }
        public string applicationName { get; set; } = "";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            applicationName = ApplicationInformationService.GetApplicationName();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Delay(1000).ContinueWith((_) => showTopButton = true);
                StateHasChanged();
            }
        }

        protected async Task NavigationToLogin()
        {
            NavigationManager.NavigateTo("/login", true);
        }

        protected async Task ChangeTextToEnglish()
        {
            LocalizerService.SetSpecificCulture("en");

        }
    }
}
