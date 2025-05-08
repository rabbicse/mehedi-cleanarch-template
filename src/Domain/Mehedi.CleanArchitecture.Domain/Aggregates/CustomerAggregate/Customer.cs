// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Mehedi.CleanArchitecture.Domain.ValueObjects;
using Mehedi.Core.SharedKernel;

namespace Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate;

public class Customer(string name, PhoneNumber? phone) : BaseEntity<Guid>, IAggregateRoot
{
    public string? Name { get; private set; } = name;
    public PhoneNumber? PhoneNumber { get; private set; } = phone;

    public void SetName(string name) => Name = name;
    public void SetPhoneNumber(PhoneNumber phoneNumber) => PhoneNumber = phoneNumber;
    protected override Guid GenerateNewId() => Guid.NewGuid();
}
