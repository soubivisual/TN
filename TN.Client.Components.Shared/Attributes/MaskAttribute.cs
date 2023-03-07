namespace TN.Client.Components.Shared.Attributes
{
    /// <summary>
    /// Mask for Blazor TextBox Components
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class MaskAttribute : Attribute
    {
        public string Mask { get; private set; }

        public MaskAttribute(string mask) : base()
        {
            this.Mask = mask;
        }
    }
}
