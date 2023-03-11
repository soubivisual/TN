using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Building.Shared.Mapping;
using TN.Modules.Identity.Application.Contracts;
using TN.Modules.Identity.Application.Users.Commands.AddUser;
using TN.Modules.Identity.Application.Users.Queries.GetUser;
using TN.Modules.Identity.Shared.Request;

namespace TN.Modules.Identity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityAccessModule _identityAccessModule;
        private readonly IMapping _mapping;

        public UserController(IIdentityAccessModule identityAccessModule, IMapping mapping)
        {
            _identityAccessModule = identityAccessModule;
            _mapping = mapping;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _identityAccessModule.ExecuteQueryAsync(new GetUserQuery(id));
            if (user is not null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] AddUserRequest request)
        {
            await _identityAccessModule.ExecuteCommandAsync(_mapping.Map<AddUserCommand>(request));
            //return CreatedAtAction(nameof(Get), new { userId = user.Id }, null);
            return NoContent();
        }
    }
}
