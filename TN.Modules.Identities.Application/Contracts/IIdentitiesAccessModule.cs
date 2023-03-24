using TN.Modules.Buildings.Shared.Commands;
using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Identities.Application.Contracts
{
    public interface IIdentitiesAccessModule
    {
        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
