using MasstransitRabbitMQ_Sample.Contract.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasstransitRabbitMQ_Sample.Contract.IntergarationEvent
{
    public class DomainEvent
    {
        public record EmailNotificationEvent() : INotificationEvent
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
        }
        public record SmsNotificationEvent() : INotificationEvent
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Guid TransactionId { get; set; }
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
        }
    }
}
