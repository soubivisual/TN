using TN.Modules.Building.Application.Contracts;

namespace TN.Modules.Identity.Application.Users.Commands.AddUser
{
    public record AddUserCommand(
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
