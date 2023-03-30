using TN.Modules.Buildings.Shared.Api;

namespace TN.Modules.Identities.API.Requests
{
    public sealed record AddUserRequest(
            Guid IdentificationTypeId,
            string Identification,
            string Name,
            string Username,
            string Email,
            string Phone,
            Guid TypeId,
            Guid StatusId,
            int AddedUserId,
            DateTime AddedDate) : BaseRequest;
}
