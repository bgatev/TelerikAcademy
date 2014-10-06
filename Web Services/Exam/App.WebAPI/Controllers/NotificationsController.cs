namespace App.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Http;

    using App.Data;
    using App.Models;
    using App.WebAPI.Infrastructure;

    public class NotificationsController :BaseApiController
    {
        private const int PageCount = 10;
        private IUserIdProvider userIdProvider;

        public NotificationsController(IAppData data) : base(data)
        {
        }

        public NotificationsController(IAppData data, IUserIdProvider userIdProvider)
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        // GET api/notifications
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetAllNotifications()
        {
            return Ok(GetNotificationsByPage(0));
        }

        // GET api/notifications?page=P
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetNotificationsByPage(int page)
        {
            var notifications = this.data.Notifications.All().OrderByDescending(d => d.DateCreated)
                .Skip(page * PageCount)
                .Take(10);

            foreach (var notification in notifications)
            {
                notification.Type = NotificationType.Read;
            }

            this.data.SaveChanges();

            return Ok(notifications);
        }

        // GET api/notifications/next
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetNotificationsNext()
        {
            var notification = this.data.Notifications.All().Where(t =>t.Type == NotificationType.Unread).OrderBy(d => d.DateCreated).FirstOrDefault();

            if (notification == null) return NotFound();//return HttpStatusCode.NotModified;

            return Ok(notification);
        }
    }
}