using TN.Modules.Building.Application.Contracts;

namespace TN.Modules.Logger.Application.ApplicationLogs.Queries.GetApplicationLog
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
