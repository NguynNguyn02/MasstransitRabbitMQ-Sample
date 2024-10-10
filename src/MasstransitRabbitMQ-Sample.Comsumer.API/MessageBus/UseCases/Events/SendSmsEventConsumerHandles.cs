
using MasstransitRabbitMQ_Sample.Contract.IntergarationEvent;
using MediatR;

namespace MasstransitRabbitMQ_Sample.Comsumer.API.MessageBus.UseCases.Events
{
    public class SendSmsEventConsumerHandles : IRequestHandler<DomainEvent.SmsNotificationEvent>
    {
        private readonly ILogger<SendSmsEventConsumerHandles> _logger;


        public SendSmsEventConsumerHandles(ILogger<SendSmsEventConsumerHandles> logger)
        {
            _logger = logger;
        }


        public async Task Handle(DomainEvent.SmsNotificationEvent request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("sms da xu ly: {sms}:", request);
        }
    }
}
