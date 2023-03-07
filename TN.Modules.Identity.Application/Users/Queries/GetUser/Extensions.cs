using TN.Modules.Identity.Domain.Users.Aggregates;

namespace TN.Modules.Identity.Application.Users.Queries.GetUser
{
    internal static class Extensions
    {
        public static UserDto AsDto(this User user)
            => new()
            {
                Id = user.Id,
                IdentificationTypeId = user.IdentificationTypeId,
                Identification = user.Identification,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                TypeId = user.TypeId,
                StatusId = user.StatusId,
                AddedUserId = user.AddedUserId,
                AddedDate = user.AddedDate,
                EditedUserId = user.EditedUserId,
                EditedDate = user.EditedDate
            };
    }
}
