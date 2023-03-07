using MediatR;
using TN.Modules.Building.Application.Contracts;

namespace TN.Modules.Building.Application.Configuration
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}
