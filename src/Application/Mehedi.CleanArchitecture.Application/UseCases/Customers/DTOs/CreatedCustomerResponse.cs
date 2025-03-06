using Mehedi.Application.SharedKernel.Responses;

namespace CleanArchitecture.Application.UseCases.Customers.DTOs;


public record CreatedCustomerResponse(Guid id) : IResponse
{
    public Guid Id { get; } = id;
}

