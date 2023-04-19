using TN.Admin.Services.API.Models;
using TN.Admin.Services.API.Services.Interface;

namespace TN.Admin.Services.API.Services.Implementation
{
	public class CatalogService : ICatalogService
	{
		private static Dictionary<Guid, Catalog> _catalog = new();
		public async Task CreateCatalog(Catalog catalog)
		{
			_catalog.Add(catalog.Id, catalog);
		}

		public async Task DeleteCatalog(Guid id)
		{
			_catalog.Remove(id);
		}

		public async Task<Catalog> GetCatalog(Guid id)
		{
			return _catalog[id];
		}

		public async Task<IEnumerable<Catalog>> GetCatalogs()
		{
			return _catalog.Values;
		}

		public async Task UpdateCatalog(Catalog catalog)
		{
			_catalog[catalog.Id] = catalog;
		}
	}
}
