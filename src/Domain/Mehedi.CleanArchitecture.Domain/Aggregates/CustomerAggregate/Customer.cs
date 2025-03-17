using CleanArchitecture.Domain.ValueObjects;
using Mehedi.Core.SharedKernel;

namespace CleanArchitecture.Domain.Aggregates.CustomerAggregate;

public class Customer(string name, PhoneNumber? phone) : BaseEntity<Guid>, IAggregateRoot
{
    public string? Name { get; private set; } = name;
    public PhoneNumber? PhoneNumber { get; private set; } = phone;

    public void SetPhoneNumber(string phoneNumber) => PhoneNumber = new PhoneNumber(string.Empty, phoneNumber, string.Empty);
    protected override Guid GenerateNewId() => Guid.NewGuid();
}
