using Microsoft.Extensions.DependencyInjection;
using SnowtifyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowtifyApi.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public NotificationRepository(IServiceProvider serviceProvider)
        {
            _applicationDbContext = serviceProvider.GetService<ApplicationDbContext>();
        }

        public void CreateNotification(Notification notification)
        {
            _applicationDbContext.Notifications.Add(notification);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteNotification(Notification notification)
        {
            _applicationDbContext.Notifications.Remove(notification);
            _applicationDbContext.SaveChanges();
        }

        public Notification GetNotification(string notificationId)
        {
            return _applicationDbContext.Notifications.Where(x => string.Equals(x.Id, notificationId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public void UpdateNotification(Notification notification)
        {
            _applicationDbContext.Notifications.Update(notification);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Notification> GetNotifications(Follower follower)
        {
            return _applicationDbContext.Notifications.Where(x => x.Followers.Contains(follower));
        }
    }
}