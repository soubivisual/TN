
namespace TN.Modules.Buildings.Shared.Events.Identities
{
    public record UserCreatedEvent(int TenantId, int UserId, string Email, string Name) : IEvent;
}
