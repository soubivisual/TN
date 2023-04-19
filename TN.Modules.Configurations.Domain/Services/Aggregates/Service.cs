using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Configurations.Domain.Services.ValueObjects;

namespace TN.Modules.Configurations.Domain.Services.Aggregates
{
    public sealed class Service : AggregateRootBase<ServiceId>, IAudit, IRowVersion
    {
        public ProviderId ProviderId { get; private set; }

        public Guid CountryId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string TermsAndConditions { get; private set; }

        public Guid TypeId { get; private set; }

        public Guid StatusId { get; private set; }

        public string Metadata { get; private set; }

        public int? AddedUserId { get; private set; }

        public DateTime? AddedDate { get; private set; }

        public int? EditedUserId { get; private set; }

        public DateTime? EditedDate { get; private set; }

        public byte[] RowVersion { get; private set; }

        public Service() : base(default) { }

        public Service(ServiceId id, ProviderId providerId, Guid countryId, string name, string description, string termsAndConditions, Guid typeId, Guid statusId, string metadata) : base(id)
        {
            ProviderId = providerId;
            CountryId = countryId;
            Name = name;
            Description = description;
            TermsAndConditions = termsAndConditions;
            TypeId = typeId;
            StatusId = statusId;
            Metadata = metadata;
        }
    }
}
