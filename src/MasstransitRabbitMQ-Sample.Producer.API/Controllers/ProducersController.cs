using MassTransit;
using MasstransitRabbitMQ_Sample.Contract.Enum;
using MasstransitRabbitMQ_Sample.Contract.IntergarationEvent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MasstransitRabbitMQ_Sample.Contract.IntergarationEvent.DomainEvent;


namespace MasstransitRabbitMQ_Sample.Producer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ProducersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        [HttpPost("publish-sms-notification")]
        public async Task<IActionResult> PublishSmsNotificationEvent()
        {
            await _publishEndpoint.Publish(new DomainEvent.SmsNotificationEvent()
            {
                Id = Guid.NewGuid(),
                Description = "Sms Description",
                Name = "Sms notification",
                TimeStamp = DateTime.Now,
                TransactionId = Guid.NewGuid(),
                Type = NotificationType.sms
            });


            return Accepted();
        }
        [HttpPost("publish-email-notification")]
        public async Task<IActionResult> PublishEmailNotificationEvent()
        {
            await _publishEndpoint.Publish(new DomainEvent.EmailNotificationEvent()
            {
                Id = Guid.NewGuid(),
                Description = "Email Description",
                Name = "Email notification",
                TimeStamp = DateTime.Now,
                TransactionId = Guid.NewGuid(),
                Type = NotificationType.email
            });


            return Accepted();
        }



    }



}
