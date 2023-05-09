using TN.Client.Services.Shared.Entities;

namespace TN.Client.Services.Shared.Models
{
    public sealed class GetMenusResponse
    {
        public List<MenuEntity> Menus { get; set; }
    }
}
