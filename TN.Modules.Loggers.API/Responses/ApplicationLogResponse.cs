using TN.Modules.Buildings.Shared.Api;
using TN.Modules.Buildings.Shared.Dtos;

namespace TN.Modules.Loggers.API.Responses
{
    public class ApplicationLogResponse : BaseResponse<ApplicationLogDto>
    {
        public override ApplicationLogDto Payload { get; init; }
    }
}
