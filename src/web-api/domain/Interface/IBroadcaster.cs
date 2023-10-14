using Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
	public interface IBroadcaster
	{
		bool HasNotifications();
		List<Notification> GetNotifications(TypeNotification typeNotification);
		void ToTransmit(Notification notificacao);
	}

}

