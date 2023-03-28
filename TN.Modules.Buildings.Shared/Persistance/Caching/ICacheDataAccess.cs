using TN.Modules.Buildings.Shared.Dtos;

namespace TN.Modules.Buildings.Shared.Persistance.Caching
{
    public interface ICacheDataAccess
    {
        Task<IReadOnlyList<CatalogDto>> GetCatalog(string type);

        Task<string> GetCompany(int id);

        Task<string> GetTenant(int id);

        Task<string> GetProvider(int id);

        Task<string> GetService(int id);

        Task<UserDto> GetUser(int id);
    }
}
