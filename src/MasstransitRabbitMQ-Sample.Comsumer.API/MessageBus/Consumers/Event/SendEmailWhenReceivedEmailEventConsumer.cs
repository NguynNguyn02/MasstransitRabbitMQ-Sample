using MasstransitRabbitMQ_Sample.Comsumer.API.Abstractions.Messages;
using MasstransitRabbitMQ_Sample.Contract.IntergarationEvent;
using MediatR;

namespace MasstransitRabbitMQ_Sample.Comsumer.API.MessageBus.Consumers.Event
{
    public class SendEmailWhenReceivedEmailEventConsumer : Consumer<DomainEvent.EmailNotificationEvent>
    {
        public SendEmailWhenReceivedEmailEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
