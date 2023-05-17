using TN.Client.Services.Shared.Models;

namespace TN.Client.Services.Shared.Interfaces
{
    public interface IMenuService
    {
        Task<GetMenusResponse> GetMenus(int tenantId, Guid typeId, int? serviceId = null);
    }
}
