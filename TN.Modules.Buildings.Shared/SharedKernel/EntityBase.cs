namespace TN.Modules.Buildings.Shared.SharedKernel
{
    public abstract class EntityBase<TId> : IEquatable<EntityBase<TId>> where TId : notnull
    {
        public TId Id { get; set; }

        public EntityBase(TId id)
        {
            Id = id;
        }

        public override bool Equals(object obj) => obj is EntityBase<TId> entity && Id.Equals(entity.Id);

        public bool Equals(EntityBase<TId> other) => this.Equals(other);

        public static bool operator ==(EntityBase<TId> obj1, EntityBase<TId> obj2) => obj1.Equals(obj2);

        public static bool operator !=(EntityBase<TId> obj1, EntityBase<TId> obj2) => !obj1.Equals(obj2);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
