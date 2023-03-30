using TN.Modules.Buildings.Shared.Api;
using TN.Modules.Buildings.Shared.Dtos;

namespace TN.Modules.Identities.API.Responses
{
    public class UserResponse : BaseResponse<UserDto>
    {
        public override UserDto Payload { get; init; }
    }
}
