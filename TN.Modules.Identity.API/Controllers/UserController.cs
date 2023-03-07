using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Identity.Application.Contracts;
using TN.Modules.Identity.Application.Users.Commands.AddUser;
using TN.Modules.Identity.Application.Users.Queries.GetUser;

namespace TN.Modules.Identity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityAccessModule _identityAccessModule;

        public UserController(IIdentityAccessModule identityAccessModule)
        {
            _identityAccessModule = identityAccessModule;
        }

        [HttpGet("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> Get(int userId)
        {
            var user = await _identityAccessModule.ExecuteQueryAsync(new GetUserQuery(userId));
            if (user is not null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] AddUserCommand command)
        {
            await _identityAccessModule.ExecuteCommandAsync(command);
            //return CreatedAtAction(nameof(Get), new { userId = user.Id }, null);
            return NoContent();
        }

        //[HttpPut("{userId:int}/verify")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> Post(int userId)
        //{
        //    await _usersService.VerifyAsync(userId);
        //    return NoContent();
        //}
    }
}
