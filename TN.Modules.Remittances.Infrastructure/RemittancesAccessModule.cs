using MediatR;
using TN.Modules.Buildings.Shared.Commands;
using TN.Modules.Buildings.Shared.Queries;
using TN.Modules.Remittances.Application.Contracts;

namespace TN.Modules.Remittances.Infrastructure
{
    public sealed class RemittancesAccessModule : IRemittancesAccessModule
    {
        private readonly IMediator _mediator;

        public RemittancesAccessModule(IMediator mediator)
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
