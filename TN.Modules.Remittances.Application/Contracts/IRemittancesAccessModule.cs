using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Remittances.Application.Contracts
{
    public interface IRemittancesAccessModule
    {
        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
