using Domain.Interface;
using Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace ApiApplication.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IBroadcaster _broadcaster;
        //private readonly ILogger<BaseApiController> _logger;

        public BaseApiController(IBroadcaster broadcaster)
        {
            _broadcaster = broadcaster;
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(v => v.Errors);
                foreach (var erro in errors)
                {
                    var message = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    _broadcaster.ToTransmit(new Notification(message, TypeNotification.Validation));
                }
            }

            return CustomResponse();
        }

        /// <summary>
        /// Response baseado nas notificações emitidas.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected ActionResult CustomResponse(object result = null)
        {

            if (_broadcaster.HasNotifications())
            {
                return BadRequest(new
                {
                    data = default(object),
                    errors = _broadcaster.GetNotifications(TypeNotification.Error).Select(i => i.Message),
                    validations = _broadcaster.GetNotifications(TypeNotification.Validation).Select(i => i.Message),
                    message = new string[]{ },
                    success = false,
                });
            }

            return Ok(new
            {
                data = result,
                errors = new string[] { },
                validations = new string[] { },
                message = _broadcaster.GetNotifications(TypeNotification.Success).Select(i => i.Message),
                success = true,
            }); ;

        }

        internal void ToTransmit(string description, TypeNotification typeNotification = TypeNotification.Error )
        {
            _broadcaster.ToTransmit(new Notification(description, typeNotification));
        }

        internal void ToTransmit(IEnumerable<IdentityError> errors)
        {
            foreach (var erro in errors)
                ToTransmit(erro.Description, TypeNotification.Validation);
        }


        protected void FakeError()
        {
            _broadcaster.ToTransmit(new Notification("1 fake error acionado"));
            _broadcaster.ToTransmit(new Notification("2 fake error acionado"));
        }

    }
}
