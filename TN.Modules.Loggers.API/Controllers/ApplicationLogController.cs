using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Buildings.Shared.Controllers;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.Loggers.API.Responses;
using TN.Modules.Loggers.Application.ApplicationLogs.Queries.GetApplicationLog;

namespace TN.Modules.Loggers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationLogController : AuthBaseController
    {
        private readonly ILoggersAccessModule _loggersAccessModule;

        public ApplicationLogController(ILoggersAccessModule loggerAccessModule)
        {
            _loggersAccessModule = loggerAccessModule;
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationLogResponse>> Get(long id)
        {
            var applicationLog = await _loggersAccessModule.ExecuteQueryAsync(new GetApplicationLogQuery(id));
            if (applicationLog is not null)
            {
                return Ok(applicationLog);
            }

            return NotFound();
        }
    }
}
