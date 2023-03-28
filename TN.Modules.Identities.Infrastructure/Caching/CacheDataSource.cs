using TN.Modules.Buildings.Shared.Persistance.Caching;
using TN.Modules.Identities.Domain.Users.Repositories;

namespace TN.Modules.Identities.Infrastructure.Caching
{
    internal sealed class CacheDataSource : ICacheDataSource
    {
        private readonly IUserRepository _userRepository;

        public CacheDataSource(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Dictionary<string, object>> GetData()
        {
            var response = new Dictionary<string, object>();
            var users = await _userRepository.GetAllAsync();

            foreach (var user in users)
            {
                response[$"User_{user.Id}"] = user;
            }

            return response;
        }
    }
}
