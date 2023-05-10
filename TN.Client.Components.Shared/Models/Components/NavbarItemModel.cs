using System;
using TN.Client.Services.Shared.Entities;

namespace TN.Client.Components.Shared.Models.Components
{
    public record NavbarItemModel(int Id, int TenantId, int? ParentId, int? ServiceId, string Text, string Url, string Icon, short Order, string Role, Guid TypeId, Guid StatusId, List<MenuEntity> SubMenus) : MenuEntity(Id, TenantId, ParentId, ServiceId, Text, Url, Icon, Order, Role, TypeId, StatusId, SubMenus)
    {
        public bool Selected { get; set; }
        public NavbarItemModel(MenuEntity menu) : this(menu.Id,menu.TenantId, menu.ParentId, menu.ServiceId, menu.Text, menu.Url, menu.Icon, menu.Order, menu.Role, menu.TypeId, menu.StatusId, menu.SubMenus)
        {

        }
    }
}

