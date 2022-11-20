using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modeli;
using Newtonsoft.Json;
using System.Net;
using WebPush;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        public static List<PushSubscription> Subscriptions { get; set; } = new List<PushSubscription>();
        [HttpPost("subscribe")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public void Subscribe([FromBody] PushSubscription sub)
        {
            Subscriptions.Add(sub);
        }

        [HttpPost("unsubscribe")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public void Unsubscribe([FromBody] PushSubscription sub)
        {
            var item = Subscriptions.FirstOrDefault(s => s.Endpoint == sub.Endpoint);
            if (item != null)
            {
                Subscriptions.Remove(item);
            }
        }

        [HttpPost("broadcast")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public void Broadcast([FromBody] NotificationModel message, [FromServices] VapidDetails vapidDetails)
        {
            var client = new WebPushClient();
            var serializedMessage = JsonConvert.SerializeObject(message);
            foreach (var pushSubscription in Subscriptions)
            {
                client.SendNotification(pushSubscription, serializedMessage, vapidDetails);
            }

        }
    }
}
