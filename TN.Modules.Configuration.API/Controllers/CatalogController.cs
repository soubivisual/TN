using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TN.Modules.Configuration.Application.Contracts;

namespace TN.Modules.Configuration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IConfigurationAccessModule _configurationAccessModule;

        public CatalogController(IConfigurationAccessModule configurationAccessModule)
        {
            _configurationAccessModule = configurationAccessModule;
        }

        //[HttpGet("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<CatalogDto>> Get(Guid id)
        //{
        //    var catalog = await _configurationAccessModule.ExecuteQueryAsync(new GetCatalogQuery(id));
        //    if (catalog is not null)
        //    {
        //        return Ok(catalog);
        //    }

        //    return NotFound();
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> Post([FromBody] AddCatalogCommand command)
        //{
        //    await _configurationAccessModule.ExecuteCommandAsync(command);
        //    return NoContent();
        //}
    }
}
