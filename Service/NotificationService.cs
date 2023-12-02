using System;

namespace Kozyrev_Hriha_SP.Service
{
    public class NotificationService
    {
        public event Action<string, NotificationType> OnNotificationRequested;

        public void ShowNotification(string message, NotificationType type)
        {
            OnNotificationRequested?.Invoke(message, type);
        }
    }

    public enum NotificationType
    {
        Success,
        Error
    }
}