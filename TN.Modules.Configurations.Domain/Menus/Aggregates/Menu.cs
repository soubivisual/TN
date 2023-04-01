using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Configurations.Domain.Menus.ValueObjects;
using TN.Modules.Configurations.Domain.Services.ValueObjects;
using TN.Modules.Configurations.Domain.Tenants.ValueObjects;

namespace TN.Modules.Configurations.Domain.Menus.Aggregates
{
    public sealed class Menu : AggregateRootBase<MenuId>
    {
        public TenantId TenantId { get; private set; }

        public MenuId ParentId { get; private set; }

        public ServiceId ServiceId { get; private set; }

        public string Text { get; private set; }

        public string Url { get; private set; }

        public string Icon { get; private set; }

        public string ClaimId { get; private set; }

        public Guid StatusId { get; private set; }

        public Menu() : base(default) { }

        public Menu(MenuId id, TenantId tenantId, MenuId parentId, ServiceId serviceId, string text, string url, string icon, string claimId, Guid statusId) : base(id)
        {
            TenantId = tenantId;
            ParentId = parentId;
            ServiceId = serviceId;
            Text = text;
            Url = url;
            Icon = icon;
            ClaimId = claimId;
            StatusId = statusId;
        }
    }
}
