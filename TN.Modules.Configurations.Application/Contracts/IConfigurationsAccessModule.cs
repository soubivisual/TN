using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Configurations.Application.Contracts
{
    public interface IConfigurationsAccessModule
    {
        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
