using Domain.Interface;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using Domain.Notifications;

namespace Services
{
    public class BaseService
    {
        private readonly IBroadcaster _broadcaster;

        protected BaseService(IBroadcaster broadcaster)
        {
            _broadcaster = broadcaster;

        }
        protected bool ExecuteValidations<TV,TM>(TV validation, TM model)
            where TV : IValidator<TM> 
            where TM : EntityKey 
        {

          var result =  validation.Validate(model);
            if (result.IsValid) return true;

            NotifyValidation(result);
            return false;
        }

        private void NotifyValidation(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                NotifyAsValidation(error.ErrorMessage);
            }
        }

        protected void NotifyAsValidation(string successMessage)
        {
            _broadcaster.ToTransmit(new Notification(successMessage, TypeNotification.Validation));
        }


        protected void Notify(string errorMessage)
        {
            _broadcaster.ToTransmit(new Notification(errorMessage, TypeNotification.Error));
        }

        protected void NotifyAsSuccess(string successMessage)
        {
            _broadcaster.ToTransmit(new Notification(successMessage, TypeNotification.Success));
        }

      

    }
}
