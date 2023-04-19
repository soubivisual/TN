using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Identities.Domain.Users.ValueObjects;

namespace TN.Modules.Identities.Domain.Users.Entities
{
    public sealed class UserLogin : EntityBase<UserLoginId>
    {
        //public long TenantId { get; private set; }

        public UserId UserId { get; private set; }

        public Guid LoginProviderId { get; private set; }

        public string ProviderKey { get; private set; }

        public UserLogin() : base(default) { }

        public UserLogin(UserLoginId id, UserId userId, Guid loginProviderId, string providerKey) : base(id)
        {
            UserId = userId;
            LoginProviderId = loginProviderId;
            ProviderKey = providerKey;
        }
    }
}
