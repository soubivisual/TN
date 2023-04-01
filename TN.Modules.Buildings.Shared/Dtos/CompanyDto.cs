using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Buildings.Shared.Dtos
{
    public sealed class CompanyDto : BaseDto, IAudit, IRowVersion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Guid TypeId { get; set; }

        public Guid StatusId { get; set; }

        public string Metadata { get; set; }

        public int? AddedUserId { get; set; }

        public DateTime? AddedDate { get; set; }

        public int? EditedUserId { get; set; }

        public DateTime? EditedDate { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
