using MediatR;
using TN.Modules.Identities.Application.Contracts;
using TN.Modules.Buildings.Shared.Commands;
using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Identities.Infrastructure
{
    public sealed class IdentitiesAccessModule : IIdentitiesAccessModule
    {
        private readonly IMediator _mediator;

        public IdentitiesAccessModule(IMediator mediator)
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
