using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Identities.Application.Users.Queries.GetUser
{
    public sealed record GetUserQuery(int UserId) : IQuery<UserDto>
    {
        
    }
}
