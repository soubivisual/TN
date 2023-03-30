using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Queries;
using TN.Modules.Loggers.Domain.ApplicationLogs.Repositories;

namespace TN.Modules.Loggers.Application.ApplicationLogs.Queries.GetApplicationLog
{
    internal class GetApplicationLogQueryHandler : IQueryHandler<GetApplicationLogQuery, ApplicationLogDto>
    {
        private readonly IApplicationLogRepository _applicationLogRepository;
        private readonly IMapping _mapping;

        public GetApplicationLogQueryHandler(IApplicationLogRepository applicationLogRepository, IMapping mapping)
        {
            _applicationLogRepository = applicationLogRepository;
            _mapping = mapping;
        }

        public async Task<ApplicationLogDto> Handle(GetApplicationLogQuery request, CancellationToken cancellationToken)
        {
            var applicationLog = await _applicationLogRepository.GetAsync(request.ApplicationLogId);
            return _mapping.Map<ApplicationLogDto>(applicationLog);
        }
    }
}
