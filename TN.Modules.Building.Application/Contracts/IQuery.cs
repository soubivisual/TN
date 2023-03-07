using MediatR;

namespace TN.Modules.Building.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        
    }
}
