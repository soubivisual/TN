namespace TN.Modules.Buildings.Shared.SharedKernel
{
    public abstract class MultipleValueObjectBase : IEquatable<MultipleValueObjectBase>
    {
        public abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var valueObject = obj as MultipleValueObjectBase;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public bool Equals(MultipleValueObjectBase other) => Equals(other);

        public static bool operator ==(MultipleValueObjectBase obj1, MultipleValueObjectBase obj2) => Equals(obj1, obj2);

        public static bool operator !=(MultipleValueObjectBase obj1, MultipleValueObjectBase obj2) => !Equals(obj1, obj2);

        public override int GetHashCode() => 
            GetEqualityComponents().
            Select(q => q?.GetHashCode() ?? 0)
            .Aggregate((q, p) => q ^ p);

        public override string ToString() => string.Join(",", GetEqualityComponents());
    }
}
