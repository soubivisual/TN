namespace TN.Client.Services.Remittance.Interfaces
{
    public interface IRemittanceService
    {
        Task<string> Send(string data);
    }
}
