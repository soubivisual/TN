using TN.Modules.Buildings.Shared.Api;
using TN.Modules.Buildings.Shared.Dtos;

namespace TN.Modules.Configurations.API.Responses
{
    public class CatalogResponse : BaseResponse<CatalogDto>
    {
        public override CatalogDto Payload { get; init; }
    }
}
