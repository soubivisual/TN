using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Identities.Application.Contracts
{
    public interface ILoggersAccessModule
    {
        //Task ExecuteCommandAsync(ICommand command);

        //Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
