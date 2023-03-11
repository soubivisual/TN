using MediatR;
using TN.Modules.Building.Application.Contracts;
using TN.Modules.Configuration.Application.Contracts;

namespace TN.Modules.Configuration.Infrastructure
{
    public sealed class ConfigurationAccessModule : IConfigurationAccessModule
    {
        private readonly IMediator _mediator;

        public ConfigurationAccessModule(IMediator mediator)
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
