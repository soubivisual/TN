using MediatR;
using TN.Modules.Buildings.Application.Contracts;
using TN.Modules.Identities.Application.Contracts;

namespace TN.Modules.Loggers.Infrastructure
{
    public sealed class LoggersAccessModule : ILoggersAccessModule
    {
        private readonly IMediator _mediator;

        public LoggersAccessModule(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task ExecuteCommandAsync(ICommand command)
        //    => await _mediator.Send(command);

        //public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        //    => await _mediator.Send(command);

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
            => await _mediator.Send(query);
    }
}
