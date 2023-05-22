using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.Modules.Buildings.Shared.Controllers;
using TN.Modules.Buildings.Shared.Mapper;
using TN.Modules.Notifications.API.Responses;
using TN.Modules.Notifications.Application.Contracts;
using TN.Modules.Notifications.Application.Notifications.Queries.GetNotification;

namespace TN.Modules.Notifications.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class NotificationController : AuthBaseController
    {
        private readonly INotificationsAccessModule _notificationsAccessModule;
        private readonly IMapping _mapping;

        public NotificationController(INotificationsAccessModule notificationsAccessModule, IMapping mapping)
        {
            _notificationsAccessModule = notificationsAccessModule;
            _mapping = mapping;
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NotificationResponse>> Get(long id)
        {
            var notification = await _notificationsAccessModule.ExecuteQueryAsync(new GetNotificationQuery(id));
            if (notification is not null)
            {
                var response = _mapping.Map<NotificationResponse>(notification);
                return Ok(response);
            }

            return NotFound();
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> Post(AddNotificationRequest request)
        //{
        //    var command = _mapping.Map<AddNotificationCommand>(request);
        //    await _notificationsAccessModule.ExecuteCommandAsync(command);

        //    return NoContent();
        //}
    }
}
