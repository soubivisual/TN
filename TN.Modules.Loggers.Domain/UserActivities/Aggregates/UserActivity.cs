using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Loggers.Domain.UserActivities.ValueObjects;

namespace TN.Modules.Loggers.Domain.UserActivities.Aggregates
{
    public sealed class UserActivity : AggregateRootBase<UserActivityId>
    {
        public int? TenantId { get; private set; }

        public int? UserId { get; private set; }

        public string Channel { get; private set; }

        public string Action { get; private set; }

        public string Detail { get; private set; }

        public DateTime Date { get; private set; }

        public string Ip { get; private set; }

        public Guid? CoreProcessId { get; private set; }

        public string Data { get; private set; }

        public UserActivity() : base(default) { }

        public UserActivity(UserActivityId id, int? tenantId, int? userId, string channel, string action, string detail, DateTime date, string ip, Guid? coreProcessId, string data) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            Channel = channel;
            Action = action;
            Detail = detail;
            Date = date;
            Ip = ip;
            CoreProcessId = coreProcessId;
            Data = data;
        }
    }
}
