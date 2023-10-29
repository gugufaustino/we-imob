using Domain.Interface;

namespace Domain.Notifications
{
	public class Broadcaster : IBroadcaster
    {
        private List<Notification> _notifications;
        public Broadcaster()
        {
            _notifications = new List<Notification>();
        }
        public List<Notification> GetNotifications(TypeNotification typeNotification)
        {
            return _notifications.Where(i=> i.TypeNotification == typeNotification).ToList();
        }

        public bool HasNotifications()
        {
            return _notifications.Any(i=> i.TypeNotification == TypeNotification.Error || i.TypeNotification == TypeNotification.Validation );
        }

        public void ToTransmit(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
