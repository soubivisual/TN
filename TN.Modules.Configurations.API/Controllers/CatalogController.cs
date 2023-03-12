using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Buildings.Shared.Mapping;
using TN.Modules.Configurations.Application.Catalogs.Commands.AddCatalog;
using TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalog;
using TN.Modules.Configurations.Application.Contracts;
using TN.Modules.Configurations.Shared.Requests;

namespace TN.Modules.Configurations.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IConfigurationsAccessModule _configurationAccessModule;
        private readonly IMapping _mapping;

        public CatalogController(IConfigurationsAccessModule configurationAccessModule, IMapping mapping)
        {
            _configurationAccessModule = configurationAccessModule;
            _mapping = mapping;
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<dynamic>> Get(Guid id)
        {
            var catalog = await _configurationAccessModule.ExecuteQueryAsync(new GetCatalogQuery(id));
            if (catalog is not null)
            {
                return Ok(catalog);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(AddCatalogRequest request)
        {
            var command = _mapping.Map<AddCatalogCommand>(request);
            await _configurationAccessModule.ExecuteCommandAsync(command);

            return NoContent();
        }
    }
}
