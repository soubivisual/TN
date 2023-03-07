using TN.Modules.Identity.Domain.Users.Repositories;
using TN.Modules.Building.Application.Configuration;

namespace TN.Modules.Identity.Application.Users.Queries.GetUser
{
    internal class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.Id == request.UserId);

            return user?.AsDto();
        }
    }
}
