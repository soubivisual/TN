using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Configurations.Domain.Tenants.ValueObjects;

namespace TN.Modules.Configurations.Domain.Tenants.Entities
{
    public sealed class Company : EntityBase<CompanyId>, IAudit, IRowVersion
    {
        public string Name { get; private set; }

        public Guid TypeId { get; private set; }

        public Guid StatusId { get; private set; }

        public string Metadata { get; private set; }

        public int? AddedUserId { get; private set; }

        public DateTime? AddedDate { get; private set; }

        public int? EditedUserId { get; private set; }

        public DateTime? EditedDate { get; private set; }

        public byte[] RowVersion { get; private set; }

        public Company() : base(default) { }

        public Company(CompanyId id, string name, Guid typeId, Guid statusId, string metadata) : base(id)
        {
            Name = name;
            TypeId = typeId;
            StatusId = statusId;
            Metadata = metadata;
        }
    }
}
