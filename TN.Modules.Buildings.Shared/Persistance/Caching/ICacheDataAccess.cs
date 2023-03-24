namespace TN.Modules.Buildings.Shared.Persistance.Caching
{
    public interface ICacheDataAccess
    {
        Task<IReadOnlyList<T>> GetCatalog<T>();

        Task<string> GetCompany(int id);

        Task<string> GetTenant(int id);

        Task<string> GetProvider(int id);

        Task<string> GetService(int id);

        Task<string> GetUser(int id);
    }
}
