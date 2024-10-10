using MasstransitRabbitMQ_Sample.Comsumer.API.Abstractions.Messages;
using MasstransitRabbitMQ_Sample.Contract.IntergarationEvent;
using MediatR;

namespace MasstransitRabbitMQ_Sample.Comsumer.API.MessageBus.Consumers.Event
{
    public class SendSmsWhenReceivedSmsEventConsumer : Consumer<DomainEvent.SmsNotificationEvent>
    {
        public SendSmsWhenReceivedSmsEventConsumer(ISender sender) : base(sender)
        {

        }
    }
}
