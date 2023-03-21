﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TN.Modules.Buildings.Application.Contracts;
using TN.Modules.Buildings.Shared.Mapping;
using TN.Modules.Identities.Shared.Events;
using TN.Modules.Notifications.Application.Contracts;
using TN.Modules.Notifications.Application.Notifications.Queries.GetNotification;
using TN.Modules.Notifications.Infrastructure;

namespace TN.Modules.Notifications.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class NotificationController : ControllerBase
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
        public async Task<ActionResult<dynamic>> Get(long id)
        {
            var notification = await _notificationsAccessModule.ExecuteQueryAsync(new GetNotificationQuery(id));
            if (notification is not null)
            {
                return Ok(notification);
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
