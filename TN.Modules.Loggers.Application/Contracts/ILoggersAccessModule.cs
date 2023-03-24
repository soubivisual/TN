using TN.Modules.Buildings.Shared.Queries;

namespace TN.Modules.Identities.Application.Contracts
{
    public interface ILoggersAccessModule
    {
        //Task ExecuteCommandAsync(ICommand command);

        //Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
