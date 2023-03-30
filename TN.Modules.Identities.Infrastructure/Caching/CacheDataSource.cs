using TN.Modules.Buildings.Shared.Persistance.Caching;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.Identities.Application.Users.Queries.GetAllUsers;

namespace TN.Modules.Identities.Infrastructure.Caching
{
    internal sealed class CacheDataSource : ICacheDataSource
    {
        private readonly IIdentitiesAccessModule _identitiesAccessModule;

        public CacheDataSource(IIdentitiesAccessModule identitiesAccessModule)
        {
            _identitiesAccessModule = identitiesAccessModule;
        }

        public async Task<Dictionary<string, object>> GetData()
        {
            var response = new Dictionary<string, object>();
            var users = await _identitiesAccessModule.ExecuteQueryAsync(new GetAllUsersQuery());

            foreach (var user in users)
            {
                response[$"User_{user.Id}"] = user;
            }

            return response;
        }
    }
}
