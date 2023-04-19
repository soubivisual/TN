using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Buildings.Shared.Dtos
{
    public sealed class UserDto : BaseDto, IAudit, IRowVersion
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

        public byte[] RowVersion { get; set; }
    }
}
