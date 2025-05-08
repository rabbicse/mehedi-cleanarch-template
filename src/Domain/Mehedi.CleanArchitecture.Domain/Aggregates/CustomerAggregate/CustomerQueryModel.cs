using Mehedi.CleanArchitecture.Domain.ValueObjects;
using Mehedi.Core.SharedKernel;

namespace Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate;

public record CustomerQueryModel(Guid Id, string Name, PhoneNumber Phone) : IQueryModel<Guid>;
