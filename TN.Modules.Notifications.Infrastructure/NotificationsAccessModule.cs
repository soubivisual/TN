using MediatR;
using TN.Modules.Buildings.Shared.Commands;
using TN.Modules.Buildings.Shared.Queries;
using TN.Modules.Notifications.Application.Contracts;

namespace TN.Modules.Notifications.Infrastructure
{
    public sealed class NotificationsAccessModule : INotificationsAccessModule
    {
        private readonly IMediator _mediator;

        public NotificationsAccessModule(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ExecuteCommandAsync(ICommand command)
            => await _mediator.Send(command);

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
            => await _mediator.Send(command);

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
            => await _mediator.Send(query);
    }
}
