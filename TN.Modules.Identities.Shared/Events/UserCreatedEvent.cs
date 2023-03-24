using TN.Modules.Buildings.Shared.Events;

namespace TN.Modules.Identities.Shared.Events
{
    public record UserCreatedEvent(int TenantId, int UserId, string Email, string Name) : IEvent;
}
