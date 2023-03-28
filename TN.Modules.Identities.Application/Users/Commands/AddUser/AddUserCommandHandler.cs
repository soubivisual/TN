using TN.Modules.Identities.Domain.Users.Entities;
using TN.Modules.Identities.Domain.Users.Repositories;
using TN.Modules.Buildings.Shared.Commands;
using TN.Modules.Buildings.Shared.Messaging;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Events.Identities;

namespace TN.Modules.Identities.Application.Users.Commands.AddUser
{
    internal class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageBusPublisher _messageBusClient;
        private readonly IMapping _mapping;

        public AddUserCommandHandler(IUserRepository userRepository, IMessageBusPublisher messageBusClient, IMapping mapping)
        {
            _userRepository = userRepository;
            _messageBusClient = messageBusClient;
            _mapping = mapping;
        }

        public async Task Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var user = _mapping.Map<User>(command);
            await _userRepository.AddAsync(user);
            _messageBusClient.Publish(new UserCreatedEvent(1, 1, user.Email, user.Name));
        }
    }
}
