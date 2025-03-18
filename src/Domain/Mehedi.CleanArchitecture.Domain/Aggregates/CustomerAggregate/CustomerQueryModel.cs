using CleanArchitecture.Domain.ValueObjects;
using Mehedi.Core.SharedKernel;

namespace CleanArchitecture.Domain.Aggregates.CustomerAggregate;

public record CustomerQueryModel(Guid Id, string Name, PhoneNumber Phone) : IQueryModel<Guid>;
