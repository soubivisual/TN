using System;
using Microsoft.AspNetCore.Components;
using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Components.Authentication.Pages.FirstPage
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
            NavigationManager.NavigateTo("/MapPage", true);
        }

        protected async Task ChangeTextToEnglish()
        {
            LocalizerService.SetSpecificCulture("en");

        }
    }
}

