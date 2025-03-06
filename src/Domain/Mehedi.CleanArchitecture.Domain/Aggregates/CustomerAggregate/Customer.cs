using CleanArchitecture.Domain.ValueObjects;
using Mehedi.Core.SharedKernel;

namespace CleanArchitecture.Domain.Aggregates.CustomerAggregate;

public class Customer : BaseEntity<Guid>, IAggregateRoot
{
    public string? Name { get; set; }
    public PhoneNumber? PhoneNumber { get; private set; }

    public void SetPhoneNumber(string phoneNumber) => PhoneNumber = new PhoneNumber(string.Empty, phoneNumber, string.Empty);
    protected override Guid GenerateNewId() => Guid.NewGuid();
}
