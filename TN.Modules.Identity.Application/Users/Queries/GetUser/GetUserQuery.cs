using TN.Modules.Building.Application.Contracts;

namespace TN.Modules.Identity.Application.Users.Queries.GetUser
{
    public sealed class GetUserQuery : IQuery<UserDto>
    {
        public GetUserQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
