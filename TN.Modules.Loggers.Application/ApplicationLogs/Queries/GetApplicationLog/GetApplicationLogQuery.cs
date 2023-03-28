using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Loggers.Application.ApplicationLogs.Queries.GetApplicationLog
{
    public sealed class GetApplicationLogQuery : IQuery<ApplicationLogDto>
    {
        public GetApplicationLogQuery(long applicationLogId)
        {
            ApplicationLogId = applicationLogId;
        }

        public long ApplicationLogId { get; set; }
    }
}
