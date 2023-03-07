using TN.Modules.Building.Domain.Entities;

namespace TN.Modules.Building.Domain.Aggregates
{
    public abstract class AggregateRootBase<TId> : EntityBase<TId> where TId : notnull
    {
        protected AggregateRootBase(TId id) : base(id)
        {
        }
    }
}
