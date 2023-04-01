using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Loggers.Domain.TraceLogs.ValueObjects;

namespace TN.Modules.Loggers.Domain.TraceLogs.Aggregates
{
    public sealed class TraceLog : AggregateRootBase<TraceLogId>
    {
        public int? TenantId { get; private set; }

        public int? UserId { get; private set; }

        public string Channel { get; private set; }

        public string Type { get; private set; }

        public string ClassName { get; private set; }

        public string MethodName { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public DateTime Date { get; private set; }

        public string Ip { get; private set; }

        public Guid? CoreProcessId { get; private set; }

        public string Data { get; private set; }

        public TraceLog() : base(default) { }

        public TraceLog(TraceLogId id, int? tenantId, int? userId, string channel, string type, string className, string methodName, string key, string value, DateTime date, string ip, Guid? coreProcessId, string data) : base(id)
        {
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
            Data = data;
        }
    }
}
