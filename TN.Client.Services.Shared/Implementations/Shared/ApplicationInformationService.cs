using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Services.Shared.Implementations.Shared
{
	public sealed class ApplicationInformationService : IApplicationInformation
	{
        private readonly string ApplicationName;

		public ApplicationInformationService(string applicationName)
		{
            ApplicationName = applicationName;
		}

        public string GetApplicationName()
        {
            return ApplicationName;
        }
    }
}

