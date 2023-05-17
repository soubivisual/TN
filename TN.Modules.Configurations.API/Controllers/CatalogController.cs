using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Buildings.Shared.Controllers;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Configurations.API.Requests;
using TN.Modules.Configurations.API.Responses;
using TN.Modules.Configurations.Application.Catalogs.Commands.AddCatalog;
using TN.Modules.Configurations.Application.Catalogs.Commands.UpdateCatalog;
using TN.Modules.Configurations.Application.Catalogs.Queries.GetCatalog;
using TN.Modules.Configurations.Application.Contracts;

namespace TN.Modules.Configurations.API.Controllers
{
    [Route("[controller]")]
    public sealed class CatalogController : AuthBaseController
    {
        private readonly IConfigurationsAccessModule _configurationsAccessModule;
        private readonly IMapping _mapping;

        public CatalogController(IConfigurationsAccessModule configurationAccessModule, IMapping mapping)
        {
            _configurationsAccessModule = configurationAccessModule;
            _mapping = mapping;
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CatalogResponse>> Get(Guid id)
        {
            var catalog = await _configurationsAccessModule.ExecuteQueryAsync(new GetCatalogQuery(id));
            if (catalog is not null)
            {
                var response = _mapping.Map<CatalogResponse>(catalog);
                return Ok(response);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(AddCatalogRequest request)
        {
            var command = _mapping.Map<AddCatalogCommand>(request);
            await _configurationsAccessModule.ExecuteCommandAsync(command);

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(UpdateCatalogRequest request)
        {
            var command = _mapping.Map<UpdateCatalogCommand>(request);
            await _configurationsAccessModule.ExecuteCommandAsync(command);

            return NoContent();
        }
    }
}
