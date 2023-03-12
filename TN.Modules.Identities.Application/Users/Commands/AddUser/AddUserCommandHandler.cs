using TN.Modules.IdentitiesDomain.Users.Entities;
using TN.Modules.IdentitiesDomain.Users.Repositories;
using TN.Modules.Buildings.Application.Configuration;
using TN.Modules.Buildings.Shared.Mapping;

namespace TN.Modules.Identities.Application.Users.Commands.AddUser
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
            var user = _mapping.Map<User>(command);
            await _userRepository.AddAsync(user);
        }
    }
}
