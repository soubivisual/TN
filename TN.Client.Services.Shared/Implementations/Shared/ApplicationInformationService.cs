using System;
using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Services.Shared.Implementations.Shared
{
	public class ApplicationInformationService : IApplicationInformation
	{
        protected string ApplicationName;

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

