using TN.Modules.IdentitiesDomain.Users.Repositories;
using TN.Modules.Buildings.Application.Configuration;
using TN.Modules.Buildings.Shared.Mapping;

namespace TN.Modules.Identities.Application.Users.Queries.GetUser
{
    internal class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapping _mapping;

        public GetUserQueryHandler(IUserRepository userRepository, IMapping mapping)
        {
            _userRepository = userRepository;
            _mapping = mapping;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            return _mapping.Map<UserDto>(user);
        }
    }
}
