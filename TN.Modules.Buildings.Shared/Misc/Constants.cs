namespace TN.Modules.Buildings.Shared.Misc
{
    public sealed class GeneralStatus
    {
        public static readonly Guid Active = Guid.Parse("45E3DEAC-CED7-47A8-A88B-9243374FCAAD");
        public static readonly Guid Inactive = Guid.Parse("C756FCD2-2C13-4A90-93EE-83F9450B9BCE");
    }

    public sealed class Currency
    {
        public static readonly Guid Colones = Guid.Parse("93EFB174-5694-4EEB-B8CB-4D41CB860C5B");
        public static readonly Guid Dollars = Guid.Parse("3B65D54A-08FF-4AB4-BFB9-EADFDF380A62");
    }

    public class CatalogType
    {
        public const string GeneralStatus = "GeneralStatus";
        public const string Currency = "Currency";
    }
}
