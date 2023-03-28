using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Buildings.Shared.Queries;
using TN.Modules.Identities.Domain.Users.Repositories;

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
