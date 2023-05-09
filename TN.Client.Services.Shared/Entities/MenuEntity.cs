namespace TN.Client.Services.Shared.Entities
{
    public record MenuEntity(
        int Id,
        int TenantId,
        int? ParentId,
        int? ServiceId,
        string Text,
        string Url,
        string Icon,
        short Order,
        string Role,
        Guid TypeId,
        Guid StatusId,
        List<MenuEntity> SubMenus);
}
