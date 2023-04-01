using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Buildings.Shared.Dtos
{
    public sealed class MenuDto : BaseDto, IAudit, IRowVersion
    {
        public int Id { get; set; }

        public int TenantId { get; set; }

        public int MenuId { get; set; }

        public int ServiceId { get; set; }

        public string Text { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public string ClaimId { get; set; }

        public Guid StatusId { get; set; }

        public int? AddedUserId { get; set; }

        public DateTime? AddedDate { get; set; }

        public int? EditedUserId { get; set; }

        public DateTime? EditedDate { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
