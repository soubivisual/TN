using MediatR;

namespace TN.Modules.Building.Application.Contracts
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        
    }

    public interface ICommand : IRequest
    {
        
    }
}
