﻿namespace TN.Modules.Buildings.Shared.SharedKernel
{
    public abstract class ValueObjectBase<TValue> : IEquatable<ValueObjectBase<TValue>> where TValue : IEquatable<TValue>
    {
        public TValue Value { get; }

        protected ValueObjectBase(TValue value)
        {
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

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();
    }
}
