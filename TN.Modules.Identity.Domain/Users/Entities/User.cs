using TN.Modules.Building.Domain.Entities;
using TN.Modules.Identity.Domain.Users.ValueObjects;

namespace TN.Modules.Identity.Domain.Users.Aggregates
{
    public sealed class User : EntityBase<UserId>
    {
        public Guid IdentificationTypeId { get; private set; }

        public string Identification { get; private set; }

        public Name Name { get; private set; }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public Guid TypeId { get; private set; }

        public Guid StatusId { get; private set; }

        public int? AddedUserId { get; private set; }

        public DateTime? AddedDate { get; private set; }

        public int? EditedUserId { get; private set; }

        public DateTime? EditedDate { get; private set; }

        public User(UserId id, Guid identificationTypeId, string identification, Name name, string username, string email, string phone, Guid typeId, Guid statusId, int? addedUserId, DateTime? addedDate) : base(id)
        {
            Id = id;
            IdentificationTypeId = identificationTypeId;
            Identification = identification;
            Name = name;
            Username = username;
            Email = email;
            Phone = phone;
            TypeId = typeId;
            StatusId = statusId;
            AddedUserId = addedUserId;
            AddedDate = addedDate;
        }
    }
}
