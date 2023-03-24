using MediatR;

namespace TN.Modules.Buildings.Shared.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        
    }

    public interface ICommand : IRequest
    {
        
    }
}
