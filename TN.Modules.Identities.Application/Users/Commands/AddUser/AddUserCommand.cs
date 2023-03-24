using TN.Modules.Buildings.Shared.Commands;

namespace TN.Modules.Identities.Application.Users.Commands.AddUser
{
    public sealed record AddUserCommand(
            Guid IdentificationTypeId,
            string Identification,
            string Name,
            string Username,
            string Email,
            string Phone,
            Guid TypeId,
            Guid StatusId,
            int AddedUserId,
            DateTime AddedDate) : ICommand;
}
