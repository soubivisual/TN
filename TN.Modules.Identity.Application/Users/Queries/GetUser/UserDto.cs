namespace TN.Modules.Identity.Application.Users.Queries.GetUser
{
    public sealed class UserDto
    {
        public int Id { get; set; }

        public Guid IdentificationTypeId { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Guid TypeId { get; set; }

        public Guid StatusId { get; set; }

        public int? AddedUserId { get; set; }

        public DateTime? AddedDate { get; set; }

        public int? EditedUserId { get; set; }

        public DateTime? EditedDate { get; set; }
    }
}
