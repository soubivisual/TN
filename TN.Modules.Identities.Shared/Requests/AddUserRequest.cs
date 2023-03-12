namespace TN.Modules.IdentitiesShared.Requests
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
            DateTime AddedDate);
}
