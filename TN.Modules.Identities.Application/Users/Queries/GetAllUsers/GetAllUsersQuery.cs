using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Identities.Application.Users.Queries.GetAllUsers
{
    public sealed record GetAllUsersQuery() : IQuery<IReadOnlyList<UserDto>>
    {
        
    }
}
