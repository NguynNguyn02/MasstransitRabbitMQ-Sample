
using MassTransit;
using MediatR;

namespace MasstransitRabbitMQ_Sample.Contract.Abstractions.Messages;
[ExcludeFromTopology]

public interface IMessage:IRequest
{
    public Guid Id { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
}
