using TN.Modules.Building.Application.Configuration;
using TN.Modules.Logger.Domain.ApplicationLogs.Repositories;

namespace TN.Modules.Logger.Application.ApplicationLogs.Queries.GetApplicationLog
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
