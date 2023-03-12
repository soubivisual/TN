using MediatR;

namespace TN.Modules.Buildings.Application.Contracts
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        
    }

    public interface ICommand : IRequest
    {
        
    }
}
