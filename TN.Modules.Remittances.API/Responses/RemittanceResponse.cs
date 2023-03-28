using TN.Modules.Buildings.Shared.Api;

namespace TN.Modules.Remittances.API.Responses
{
    public class RemittanceResponse : BaseResponse<object>
    {
        public override object Payload { get; init; }
    }
}
