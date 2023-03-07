using MediatR;
using TN.Modules.Identity.Application.Contracts;
using TN.Modules.Building.Application.Contracts;

namespace TN.Modules.Identity.Infrastructure
{
    public sealed class IdentityAccessModule : IIdentityAccessModule
    {
        private readonly IMediator _mediator;

        public IdentityAccessModule(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await _mediator.Send(command);
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await _mediator.Send(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            return await _mediator.Send(query);
        }
    }
}
