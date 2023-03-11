using TN.Modules.Logger.Domain.ApplicationLogs.Enums;

namespace TN.Modules.Logger.Application.ApplicationLogs.Queries.GetApplicationLog
{
    public sealed class ApplicationLogDto
    {
        public long Id { get; set; }

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
    }
}
