using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Buildings.Shared.Controllers;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Remittances.API.Responses;
using TN.Modules.Remittances.Application.Contracts;
using TN.Modules.Remittances.Application.Remittances.Queries.GetRemittance;

namespace TN.Modules.Remittances.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class RemittanceController : AuthBaseController
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
        public async Task<ActionResult<RemittanceResponse>> Get(long id)
        {
            var remittance = await _remittancesAccessModule.ExecuteQueryAsync(new GetRemittanceQuery(id));
            if (remittance is not null)
            {
                var response = _mapping.Map<RemittanceResponse>(remittance);
                return Ok(response);
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
