namespace TN.Modules.Building.Domain.ValueObjects
{
    public abstract class ValueObjectBase<TValue> : IEquatable<ValueObjectBase<TValue>> where TValue : IEquatable<TValue>
    {
        public TValue Value { get; }

        protected ValueObjectBase(TValue value)
        {
            //if (value == null)
            //{
            //    throw new ArgumentNullException(nameof(value));
            //}

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ValueObjectBase<TValue> other && Equals(other);
        }

        public bool Equals(ValueObjectBase<TValue> other) => this.Value.Equals(other.Value);

        public static bool operator ==(ValueObjectBase<TValue> obj1, ValueObjectBase<TValue> obj2) => obj1.Equals(obj2);

        public static bool operator !=(ValueObjectBase<TValue> obj1, ValueObjectBase<TValue> obj2) => !obj1.Equals(obj2);

        public static implicit operator TValue(ValueObjectBase<TValue> value) => value.Value;

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();
    }
}
