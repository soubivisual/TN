using TN.Modules.Buildings.Shared.Dtos;
using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Identities.Application.Users.Queries.GetUser
{
    public sealed record GetUserQuery(int UserId) : IQuery<UserDto>
    {
        
    }
}
