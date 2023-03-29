using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Buildings.Shared.Controllers;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.Identities.Application.Users.Commands.AddUser;
using TN.Modules.Identities.Application.Users.Queries.GetUser;
using TN.Modules.Identities.API.Requests;
using TN.Modules.Identities.API.Responses;

namespace TN.Modules.Identities.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : AuthBaseController
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
        public async Task<ActionResult<UserResponse>> Get(int id)
        {
            var user = await _identitiesAccessModule.ExecuteQueryAsync(new GetAllUsersQuery(id));
            if (user is not null)
            {
                var response = _mapping.Map<UserResponse>(user);
                return Ok(response);
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
