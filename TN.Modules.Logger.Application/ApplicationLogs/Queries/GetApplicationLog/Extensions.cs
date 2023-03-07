using TN.Modules.Logger.Domain.ApplicationLogs.Entities;

namespace TN.Modules.Logger.Application.ApplicationLogs.Queries.GetApplicationLog
{
    internal static class Extensions
    {
        public static ApplicationLogDto AsDto(this ApplicationLog applicationLog)
            => new()
            {
                Id = applicationLog.Id,
                TenantId = applicationLog.TenantId,
                UserId = applicationLog.UserId,
                Channel = applicationLog.Channel,
                Type = applicationLog.Type,
                ClassName = applicationLog.ClassName,
                MethodName = applicationLog.MethodName,
                Key = applicationLog.Key,
                Value = applicationLog.Value,
                Date = applicationLog.Date,
                Ip = applicationLog.Ip,
                CoreProcessId = applicationLog.CoreProcessId,
                Message = applicationLog.Message,
            };
    }
}
