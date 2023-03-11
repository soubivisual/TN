using TN.Modules.Building.Application.Contracts;

namespace TN.Modules.Configuration.Application.Contracts
{
    public interface IConfigurationAccessModule
    {
        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
