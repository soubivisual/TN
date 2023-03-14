using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Buildings.Shared.Mapping;
using TN.Modules.Remittances.Application.Contracts;
using TN.Modules.Remittances.Application.Remittances.Queries.GetRemittance;

namespace TN.Modules.Remittances.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class RemittanceController : ControllerBase
    {
        private readonly IRemittancesAccessModule _remittancesAccessModule;
        private readonly IMapping _mapping;

        public RemittanceController(IRemittancesAccessModule remittancesAccessModule, IMapping mapping)
        {
            _remittancesAccessModule = remittancesAccessModule;
            _mapping = mapping;
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<dynamic>> Get(long id)
        {
            var remittance = await _remittancesAccessModule.ExecuteQueryAsync(new GetRemittanceQuery(id));
            if (remittance is not null)
            {
                return Ok(remittance);
            }

            return NotFound();
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> Post(AddRemittanceRequest request)
        //{
        //    var command = _mapping.Map<AddRemittanceCommand>(request);
        //    await _remittancesAccessModule.ExecuteCommandAsync(command);

        //    return NoContent();
        //}
    }
}
