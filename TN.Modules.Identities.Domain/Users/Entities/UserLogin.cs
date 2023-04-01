using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Identities.Domain.Users.ValueObjects;

namespace TN.Modules.Identities.Domain.Users.Entities
{
    public sealed class UserLogin : EntityBase<long>
    {
        public long TenantId { get; private set; }

        public UserId UserId { get; private set; }

        public Guid LoginProviderId { get; private set; }

        public string ProviderKey { get; private set; }

        public UserLogin(long id) : base(id) { }

        public UserLogin(UserId id, long tenantId, UserId userId, Guid loginProviderId, string providerKey) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            LoginProviderId = loginProviderId;
            ProviderKey = providerKey;
        }
    }
}
