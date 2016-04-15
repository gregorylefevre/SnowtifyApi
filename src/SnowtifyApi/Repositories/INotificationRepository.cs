using SnowtifyApi.Models;
using System.Collections.Generic;

namespace SnowtifyApi.Repositories
{
    public interface INotificationRepository
    {
        void CreateNotification(Notification notification);

        void DeleteNotification(Notification notification);

        Notification GetNotification(string notificationId);

        void UpdateNotification(Notification notification);

        IEnumerable<Notification> GetNotifications(Follower follower);
    }
}