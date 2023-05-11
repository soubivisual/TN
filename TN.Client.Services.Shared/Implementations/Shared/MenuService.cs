﻿using TN.Client.Services.Shared.Entities;
using TN.Client.Services.Shared.Interfaces;
using TN.Client.Services.Shared.Models;

namespace TN.Client.Services.Shared.Implementations.Shared
{
    public sealed class MenuService : IMenuService
    {
        public Task<GetMenusResponse> GetMenus(int tenantId, Guid typeId)
        {
            var menus = new List<MenuEntity>
            {
                new MenuEntity(1, 1, null, null, "Home", "/dashboard", "feather icon-home", 1, null, MenuType.Left, GeneralStatus.Active, new List<MenuEntity>()),
                new MenuEntity(2, 1, null, null, "Remesas", "/remittances", "feather icon-credit-card", 2, null, MenuType.Left, GeneralStatus.Active, new List<MenuEntity>
                {
                    new MenuEntity(6, 1, null, null, "Envíos", "/remittances/send", "", 1, null, MenuType.Left, GeneralStatus.Active, new List<MenuEntity>()),
                    new MenuEntity(7, 1, null, null, "Recepciones", "/remittances/receive", "", 2, null, MenuType.Left, GeneralStatus.Active, new List<MenuEntity>()),
                }),
                new MenuEntity(3, 1, null, null, "Ubicaciones", "/locations", "feather icon-globe", 3, null, MenuType.Left, GeneralStatus.Active, new List<MenuEntity>()),
                new MenuEntity(4, 1, null, null, "Promociones", "/promos", "feather icon-briefcase", 4, null, MenuType.Left, GeneralStatus.Active, new List<MenuEntity>()),
                new MenuEntity(5, 1, null, null, "Configuración", "/configuration", "feather icon-settings", 5, null, MenuType.Left, GeneralStatus.Active, new List<MenuEntity>()),
                new MenuEntity(8, 1, null, null, "Remesas", "/remittances", "feather icon-credit-card", 1, null, MenuType.Botton, GeneralStatus.Active, new List<MenuEntity>()),
                new MenuEntity(9, 1, null, null, "Información", "/information", "feather icon-info", 2, null, MenuType.Botton, GeneralStatus.Active, new List<MenuEntity>())
            };

            var response = new GetMenusResponse
            {
                Menus = menus
                .Where(q => q.TenantId == tenantId)
                .Where(q => q.TypeId == typeId)
                .ToList()
            };

            return Task.FromResult(response);
        }
    }
}