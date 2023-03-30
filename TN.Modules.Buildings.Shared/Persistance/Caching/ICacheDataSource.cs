namespace TN.Modules.Buildings.Shared.Persistance.Caching
{
    public interface ICacheDataSource
    {
        Task<Dictionary<string, object>> GetData();
    }
}
