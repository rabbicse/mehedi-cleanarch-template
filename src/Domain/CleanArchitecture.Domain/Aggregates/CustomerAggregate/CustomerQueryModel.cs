using CleanArchitecture.Domain.ValueObjects;
using Mehedi.Core.SharedKernel;

namespace CleanArchitecture.Domain.Aggregates.CustomerAggregate;

public record CustomerQueryModel(Guid id, string name, PhoneNumber phone) : IQueryModel<Guid>
{
    public Guid Id { get; private init; } = id;
    public string name { get; private init; } = name;
    public PhoneNumber Phone { get; private init; } = phone;
}
