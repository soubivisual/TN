using MediatR;

namespace TN.Modules.Buildings.Shared.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        
    }
}
