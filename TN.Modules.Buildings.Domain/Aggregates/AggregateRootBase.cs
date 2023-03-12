using TN.Modules.Buildings.Domain.Entities;

namespace TN.Modules.Buildings.Domain.Aggregates
{
    public abstract class AggregateRootBase<TId> : EntityBase<TId> where TId : notnull
    {
        protected AggregateRootBase(TId id) : base(id)
        {
        }
    }
}
