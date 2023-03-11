using TN.Modules.Identity.Domain.Users.Repositories;
using TN.Modules.Building.Application.Configuration;
using TN.Modules.Building.Shared.Mapping;

namespace TN.Modules.Identity.Application.Users.Queries.GetUser
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
            var user = await _userRepository.FindAsync(x => x.Id == request.UserId);

            return _mapping.Map<UserDto>(user);
        }
    }
}
