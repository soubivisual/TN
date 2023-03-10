using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Buildings.Shared.Mapping;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.Identities.Application.Users.Commands.AddUser;
using TN.Modules.Identities.Application.Users.Queries.GetUser;
using TN.Modules.IdentitiesShared.Requests;

namespace TN.Modules.IdentitiesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentitiesAccessModule _identitiesAccessModule;
        private readonly IMapping _mapping;

        public UserController(IIdentitiesAccessModule identityAccessModule, IMapping mapping)
        {
            _identitiesAccessModule = identityAccessModule;
            _mapping = mapping;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _identitiesAccessModule.ExecuteQueryAsync(new GetUserQuery(id));
            if (user is not null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(AddUserRequest request)
        {
            var command = _mapping.Map<AddUserCommand>(request);
            await _identitiesAccessModule.ExecuteCommandAsync(command);

            //return CreatedAtAction(nameof(Get), new { userId = user.Id }, null);
            return NoContent();
        }
    }
}
