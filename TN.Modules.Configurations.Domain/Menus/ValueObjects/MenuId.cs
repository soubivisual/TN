using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Configurations.Domain.Menus.ValueObjects
{
    public sealed class MenuId : ValueObjectBase<int>
    {
        public MenuId(int value) : base(value) { }

        public static implicit operator MenuId(int value) => new(value);

        public static implicit operator int(MenuId value) => value.Value;
    }
}
