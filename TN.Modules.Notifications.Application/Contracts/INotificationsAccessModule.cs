using TN.Modules.Buildings.Application.Contracts;

namespace TN.Modules.Notifications.Application.Contracts
{
    public interface INotificationsAccessModule
    {
        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
