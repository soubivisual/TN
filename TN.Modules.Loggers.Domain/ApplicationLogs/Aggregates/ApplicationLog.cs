using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Loggers.Domain.ApplicationLogs.ValueObjects;

namespace TN.Modules.Loggers.Domain.ApplicationLogs.Aggregates
{
    public sealed class ApplicationLog : AggregateRootBase<ApplicationLogId>
    {
        public int? TenantId { get; private set; }

        public int? UserId { get; private set; }

        public string Channel { get; private set; }

        public ApplicationLogType Type { get; private set; }

        public string ClassName { get; private set; }

        public string MethodName { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public DateTime Date { get; private set; }

        public string Ip { get; private set; }

        public Guid? CoreProcessId { get; private set; }

        public string Message { get; private set; }

        public ApplicationLog() : base(default) { }

        public ApplicationLog(ApplicationLogId id, int? tenantId, int? userId, string channel, ApplicationLogType type, string className, string methodName, string key, string value, DateTime date, string ip, Guid? coreProcessId, string message) : base(id)
        {
            Id = id;
            TenantId = tenantId;
            UserId = userId;
            Channel = channel;
            Type = type;
            ClassName = className;
            MethodName = methodName;
            Key = key;
            Value = value;
            Date = date;
            Ip = ip;
            CoreProcessId = coreProcessId;
            Message = message;
        }
    }
}
