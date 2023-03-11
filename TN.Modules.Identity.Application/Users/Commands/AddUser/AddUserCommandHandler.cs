using TN.Modules.Identity.Domain.Users.Aggregates;
using TN.Modules.Identity.Domain.Users.Repositories;
using TN.Modules.Building.Application.Configuration;
using TN.Modules.Building.Shared.Mapping;

namespace TN.Modules.Identity.Application.Users.Commands.AddUser
{
    internal class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapping _mapping;

        public AddUserCommandHandler(IUserRepository userRepository, IMapping mapping)
        {
            _userRepository = userRepository;
            _mapping = mapping;
        }

        public async Task Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            await _userRepository.AddAsync(_mapping.Map<User>(command));
        }
    }
}
