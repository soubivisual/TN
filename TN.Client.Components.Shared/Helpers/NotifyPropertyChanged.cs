using System;
namespace TN.Client.Components.Shared.Helpers
{
	public class NotifyPropertyChanged
	{
        public event Func<long, Task> NotificationChanged;
        public event Func<Task> MenuChanged;
        public Task OnNotificationChanged(long id) => NotificationChanged?.Invoke(id);
        public Task OnMenuChanged() => MenuChanged?.Invoke();
    }
}

