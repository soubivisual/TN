using TN.Modules.Buildings.Application.Configuration;
using TN.Modules.Loggers.Domain.ApplicationLogs.Repositories;

namespace TN.Modules.Loggers.Application.ApplicationLogs.Queries.GetApplicationLog
{
    internal class GetApplicationLogQueryHandler : IQueryHandler<GetApplicationLogQuery, ApplicationLogDto>
    {
        private readonly IApplicationLogRepository _applicationLogRepository;

        public GetApplicationLogQueryHandler(IApplicationLogRepository applicationLogRepository)
        {
            _applicationLogRepository = applicationLogRepository;
        }

        public async Task<ApplicationLogDto> Handle(GetApplicationLogQuery request, CancellationToken cancellationToken)
        {
            var applicationLog = await _applicationLogRepository.GetAsync(request.ApplicationLogId);

            return applicationLog?.AsDto();
        }
    }
}
