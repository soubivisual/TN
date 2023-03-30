using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Queries;
using TN.Modules.Identities.Domain.Users.Repositories;

namespace TN.Modules.Identities.Application.Users.Queries.GetAllUsers
{
    internal class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IReadOnlyList<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapping _mapping;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapping mapping)
        {
            _userRepository = userRepository;
            _mapping = mapping;
        }

        public async Task<IReadOnlyList<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAllAsync();
            return _mapping.Map<IReadOnlyList<UserDto>>(user);
        }
    }
}
