using MasstransitRabbitMQ_Sample.Contract.IntergarationEvent;
using MediatR;

namespace MasstransitRabbitMQ_Sample.Comsumer.API.MessageBus.UseCases.Events
{
    public class SendEmailEventConsumerHandles : IRequestHandler<DomainEvent.EmailNotificationEvent>
    {
        private readonly ILogger<SendEmailEventConsumerHandles> _logger;

        public SendEmailEventConsumerHandles(ILogger<SendEmailEventConsumerHandles> logger)
        {
            _logger = logger;
        }

        

        public async Task Handle(DomainEvent.EmailNotificationEvent request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Email da xu ly : {email}",request);        }
    }
}
