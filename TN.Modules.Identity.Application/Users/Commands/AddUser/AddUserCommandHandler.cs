using TN.Modules.Identity.Domain.Users.Aggregates;
using TN.Modules.Identity.Domain.Users.Repositories;
using TN.Modules.Building.Application.Configuration;

namespace TN.Modules.Identity.Application.Users.Commands.AddUser
{
    internal class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            await _userRepository.AddAsync(new User(
                0,
                command.IdentificationTypeId,
                command.Identification,
                command.Name,
                command.Username,
                command.Email,
                command.Phone,
                command.TypeId,
                command.StatusId,
                command.AddedUserId,
                command.AddedDate));
        }
    }
}
