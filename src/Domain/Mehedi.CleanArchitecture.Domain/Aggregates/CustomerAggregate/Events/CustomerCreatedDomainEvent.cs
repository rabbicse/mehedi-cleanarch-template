using Mehedi.CleanArchitecture.Domain.ValueObjects;
using Mehedi.Core.SharedKernel;

namespace Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate.Events;

/// <summary>
/// 
/// </summary>
/// <param name="messageType"></param>
/// <param name="aggregateId"></param>
/// <param name="id"></param>
/// <param name="name"></param>
/// <param name="phone"></param>
public record CustomerCreatedDomainEvent(
    string? messageType,
    Guid aggregateId,
    Guid id,
    string name,
    PhoneNumber phone) : BaseDomainEvent(messageType, aggregateId)
{
    public Guid Id { get; private init; } = id;
    public string Name { get; private init; } = name;
    public PhoneNumber Phone { get; private init; } = phone;    
}
