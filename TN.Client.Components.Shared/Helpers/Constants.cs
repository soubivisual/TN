namespace TN.Client.Components.Shared.Helpers
{
    internal sealed class ApplicationConstant
    {
        public const string Loading = "Cargando...";
        public const int TextBoxMaximumLength = 200;
        public const int ComboBoxSearch = 10;
    }

    public enum AlertType
    {
        Primary,
        Secondary,
        Success,
        Danger,
        Warning,
        Info,
        Light,
        Dark
    }
}
