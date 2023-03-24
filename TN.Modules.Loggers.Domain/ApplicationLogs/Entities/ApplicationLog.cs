using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Loggers.Domain.ApplicationLogs.Enums;
using TN.Modules.Loggers.Domain.ApplicationLogs.ValueObjects;

namespace TN.Modules.Loggers.Domain.ApplicationLogs.Entities
{
    public sealed class ApplicationLog : EntityBase<ApplicationLogId>
    {
        public int? TenantId { get; set; }

        public int? UserId { get; set; }

        public string Channel { get; set; }

        public ApplicationLogType Type { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime Date { get; set; }

        public string Ip { get; set; }

        public Guid? CoreProcessId { get; set; }

        public string Message { get; set; }

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
