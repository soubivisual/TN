using MediatR;
using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Buildings.Application.Configuration
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}
