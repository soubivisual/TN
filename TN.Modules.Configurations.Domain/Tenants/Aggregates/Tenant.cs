using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Configurations.Domain.Tenants.ValueObjects;

namespace TN.Modules.Configurations.Domain.Tenants.Aggregates
{
    public sealed class Tenant : AggregateRootBase<TenantId>
    {
        public CompanyId CompanyId { get; private set; }

        public Guid CountryId { get; private set; }

        public string Name { get; private set; }

        public Guid TypeId { get; private set; }

        public Guid StatusId { get; private set; }

        public string Metadata { get; private set; }

        public Tenant() : base(default) { }

        public Tenant(TenantId id, CompanyId companyId, Guid countryId, string name, Guid typeId, Guid statusId, string metadata) : base(id)
        {
            CompanyId = companyId;
            CountryId = countryId;
            Name = name;
            TypeId = typeId;
            StatusId = statusId;
            Metadata = metadata;
        }
    }
}
