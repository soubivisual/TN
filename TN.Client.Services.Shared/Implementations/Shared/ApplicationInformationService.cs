using Microsoft.Extensions.Options;
using TN.Client.Services.Shared.Configurations;
using TN.Client.Services.Shared.Interfaces;

namespace TN.Client.Services.Shared.Implementations.Shared
{
	public sealed class ApplicationInformationService : IApplicationInformation
    {
        private readonly IOptions<ApplicationServiceOptions> _options;

        public ApplicationInformationService(IOptions<ApplicationServiceOptions> options)
		{
            _options = options;
        }

        public string GetApplicationName()
        {
            return _options.Value.ApplicationName;
        }
    }
}

