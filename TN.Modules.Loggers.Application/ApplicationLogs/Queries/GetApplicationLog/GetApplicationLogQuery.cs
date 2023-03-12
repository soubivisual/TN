using TN.Modules.Buildings.Application.Contracts;

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
