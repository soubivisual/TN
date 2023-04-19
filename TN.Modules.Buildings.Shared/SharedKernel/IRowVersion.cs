namespace TN.Modules.Buildings.Shared.SharedKernel
{
    public interface IRowVersion
    {
        public abstract byte[] RowVersion { get; }
    }
}
