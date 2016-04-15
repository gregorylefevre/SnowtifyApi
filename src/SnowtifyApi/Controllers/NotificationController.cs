using Microsoft.AspNet.Mvc;
using SnowtifyApi.Models;
using SnowtifyApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SnowtifyApi.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private INotificationRepository _notificationRepository;
        private IFollowerRepository _followerRepository;

        public NotificationController(INotificationRepository notificationRepository, IFollowerRepository followerRepository)
        {
            _notificationRepository = notificationRepository;
            _followerRepository = followerRepository;
        }

        // GET: api/notification/getall/followerId
        [HttpGet("getall/{followerId}")]
        public NotificationApiResponse<IEnumerable<Notification>> GetAll(string followerId)
        {
            var now = DateTime.Now;
            try
            {
                var follower = _followerRepository.GetFollower(followerId);
                var notifications = _notificationRepository.GetNotifications(follower);
                
                return new NotificationApiResponse<IEnumerable<Notification>>
                {
                    Status = "OK",
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = notifications
                };
            }
            catch (Exception e)
            {
                Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss : ") + e.Message);
                return new NotificationApiResponse<IEnumerable<Notification>>
                {
                    Status = "KO - " + e.Message,
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = null
                };
            }
        }
        
        [HttpGet("{notificationId}")]
        public NotificationApiResponse<Notification> Get(string notificationId)
        {
            var now = DateTime.Now;
            try
            {
                var notification = _notificationRepository.GetNotification(notificationId);

                return new NotificationApiResponse<Notification>
                {
                    Status = "OK",
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = notification
                };
            }
            catch (Exception e)
            {
                Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss : ") + e.Message);
                return new NotificationApiResponse<Notification>
                {
                    Status = "KO - " + e.Message,
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = null
                };
            }
        }

        // POST api/values
        [HttpPost]
        public NotificationApiResponse<string> Post([FromBody]Notification notification)
        {
            var now = DateTime.Now;
            try
            {
                notification.Id = Guid.NewGuid().ToString();
                _notificationRepository.CreateNotification(notification);

                return new NotificationApiResponse<string>
                {
                    Status = "OK",
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = null
                };
            }
            catch (Exception e)
            {
                Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss : ") + e.Message);
                return new NotificationApiResponse<string>
                {
                    Status = "KO - " + e.Message,
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = null
                };
            }
        }

        // PUT api/values/5
        [HttpPut("{notificationId}")]
        public NotificationApiResponse<string> Put(string notificationId, [FromBody]Notification notification)
        {
            var now = DateTime.Now;
            try
            {
                notification.Id = notificationId;
                _notificationRepository.UpdateNotification(notification);

                return new NotificationApiResponse<string>
                {
                    Status = "OK",
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = null
                };
            }
            catch (Exception e)
            {
                Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss : ") + e.Message);
                return new NotificationApiResponse<string>
                {
                    Status = "KO - " + e.Message,
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = null
                };
            }
        }

        // DELETE api/values/5
        [HttpDelete("{notificationId}")]
        public NotificationApiResponse<string> Delete(string notificationId)
        {
            var now = DateTime.Now;
            try
            {
                var notification = _notificationRepository.GetNotification(notificationId);
                _notificationRepository.DeleteNotification(notification);

                return new NotificationApiResponse<string>
                {
                    Status = "OK",
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = null
                };
            }
            catch (Exception e)
            {
                Trace.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss : ") + e.Message);
                return new NotificationApiResponse<string>
                {
                    Status = "KO - " + e.Message,
                    ExecTime = (DateTime.Now - now).ToString(),
                    Body = null
                };
            }
        }
    }
}