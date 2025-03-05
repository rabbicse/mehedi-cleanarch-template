using MediatR;

namespace CleanArchitecture.Application.UseCases.Customers.Events;

public record CustomerCreatedEvent(Guid id, Guid customerId) : INotification
{
    public Guid Id { get; private init; } = id;
    public Guid CustomerId { get; private init; } = customerId;
}
