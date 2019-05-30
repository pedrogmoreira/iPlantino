using iPlantino.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace iPlantino.Services.Api.Controllers
{
    public class ApiController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        public ApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public bool IsValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        private IActionResult ResponseOk(object result)
        {
            return Ok(result);
        }

        public IActionResult ResponseBadRequest()
        {
            return BadRequest(
                _notifications
                .GetNotifications()
                .GroupBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Select(s => s.Value))
            );
        }

        public new IActionResult Response(object result)
        {
            if (IsValidOperation() && result == null)
            {
                return NotFound();
            }

            return IsValidOperation() ? ResponseOk(result) : ResponseBadRequest();
        }

        public IActionResult ResponseCreated(string uri, object result)
        {
            if (IsValidOperation() && result == null)
            {
                return NotFound();
            }

            return IsValidOperation() ? Created(uri, result) : ResponseBadRequest();
        }
    }
}