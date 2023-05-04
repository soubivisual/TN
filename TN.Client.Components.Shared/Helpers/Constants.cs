namespace TN.Client.Components.Shared.Helpers
{
    internal sealed class ApplicationConstant
    {
        public const string Loading = "Cargando...";
        public const int TextBoxMaximumLength = 200;
        public const int ComboBoxSearch = 10;
        public const string DateFormat = "yyyy-MM-dd";
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string DecimalFormat = "#,0.00";
    }

    public enum ButtonType
    {
        Button,
        Submit,
        Reset
    }

    public enum ButtonStyle
    {
        Button,
        Link
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

    public enum TooltipPosition
    {
        Top,
        Right,
        Bottom,
        Left
    }
    public enum PopoverPosition
    {
        Top,
        Right,
        Bottom,
        Left
    }
}
