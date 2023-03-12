using MediatR;
using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Buildings.Application.Configuration
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {

    }

    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {

    }
}
