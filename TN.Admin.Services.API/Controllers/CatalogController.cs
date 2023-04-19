using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using TN.Admin.Services.API.Contracts.Catalogs;
using TN.Admin.Services.API.Models;
using TN.Admin.Services.API.Services.Interface;

namespace TN.Admin.Services.API.Controllers
{
	public class CatalogController : ApiControllerBase
	{
		private readonly ICatalogService _catalogService;
		private readonly IMapper _mapper;
        public CatalogController(ICatalogService catalogService, IMapper mapper)
        {
            _catalogService = catalogService;
			_mapper = mapper;
        }

        [HttpGet]
		public async Task<ActionResult<IEnumerable<CatalogResponse>>> Get()
		{
			var catalogs = _catalogService.GetCatalogs();
			var response = _mapper.Map<IEnumerable<CatalogResponse>>(catalogs);

			return Ok(response);
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var catalog = await _catalogService.GetCatalog(id);

			var response = _mapper.Map<CatalogResponse>(catalog);	
			
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Post(CreateCatalogRequest request)
		{
			var catalog = _mapper.Map<Catalog>(request);
			catalog.Id = Guid.NewGuid();

			await _catalogService.CreateCatalog(catalog);

			var response = _mapper.Map<CatalogResponse>(request);
			response.Id = catalog.Id;

			return CreatedAtAction(
				actionName: nameof(Get),
				routeValues: new { id = catalog.Id },
				value: response);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Put(Guid id, UpdateCatalogRequest request)
		{
			var catalog = _mapper.Map<Catalog>(request);
			var response =  _catalogService.UpdateCatalog(catalog);

			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _catalogService.DeleteCatalog(id);

			return NoContent();
		}
	}
}
