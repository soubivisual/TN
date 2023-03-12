using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.Loggers.Application.ApplicationLogs.Queries.GetApplicationLog;

namespace TN.Modules.Loggers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationLogController : ControllerBase
    {
        private readonly ILoggersAccessModule _loggerAccessModule;

        public ApplicationLogController(ILoggersAccessModule loggerAccessModule)
        {
            _loggerAccessModule = loggerAccessModule;
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationLogDto>> Get(long id)
        {
            var applicationLog = await _loggerAccessModule.ExecuteQueryAsync(new GetApplicationLogQuery(id));
            if (applicationLog is not null)
            {
                return Ok(applicationLog);
            }

            return NotFound();
        }
    }
}
