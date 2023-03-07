using TN.Modules.Building.Application.Contracts;

namespace TN.Modules.Identity.Application.Contracts
{
    public interface IIdentityAccessModule
    {
        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
