namespace TN.Client.Services.Shared.Models
{
    public sealed class GeneralStatus
    {
        public static readonly Guid Active = Guid.Parse("0AEA669E-9013-47AA-8A03-3E256F7CCD36");
        public static readonly Guid Inactive = Guid.Parse("845C6895-ED92-4CC9-917F-98A96B8902F0");
    }

    public sealed class MenuType
    {
        public static readonly Guid Left = Guid.Parse("44F6D75F-142F-47AA-938B-B038EDC07412");
        public static readonly Guid Botton = Guid.Parse("D69EDA74-6F28-4802-ACD3-14641A3E61AB");
    }
}
