using MediatR;

namespace TN.Modules.Buildings.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        
    }
}
