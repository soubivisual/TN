using TN.Admin.Services.API.Models;

namespace TN.Admin.Services.API.Services.Interface
{
	public interface ICatalogService
	{
		Task CreateCatalog(Catalog catalog);
		Task DeleteCatalog(Guid id);
		Task UpdateCatalog(Catalog catalog);
		Task<Catalog> GetCatalog(Guid id);
		Task<IEnumerable<Catalog>> GetCatalogs();
	}
}
