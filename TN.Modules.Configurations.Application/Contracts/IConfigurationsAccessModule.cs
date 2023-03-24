using TN.Modules.Buildings.Shared.Commands;
using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Configurations.Application.Contracts
{
    public interface IConfigurationsAccessModule
    {
        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
