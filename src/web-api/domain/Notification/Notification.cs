using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Notifications
{
    public class Notification
    {
      
        public string Message { get; private set; }
        public TypeNotification TypeNotification { get; private set; }


        public Notification(string message, TypeNotification typeNotification = TypeNotification.Error)
        {
            Message = message;
            TypeNotification = typeNotification;
        }
    }

    public enum TypeNotification
    {
        Success,
        Error,
        Validation,
    }
}
