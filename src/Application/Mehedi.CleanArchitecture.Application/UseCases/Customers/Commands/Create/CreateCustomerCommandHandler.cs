using CleanArchitecture.Application.UseCases.Customers.DTOs;
using CleanArchitecture.Domain.Aggregates.CustomerAggregate;
using CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;
using MediatR;
using Mehedi.Application.SharedKernel.Responses;
using Mehedi.Core.SharedKernel;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Create;

public class CreateCustomerCommandHandler(ICustomerCommandRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerCommand, Result<CustomerResponse>>
{
    private readonly ICustomerCommandRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var newCustomer = new Customer(request.Name, request.phone);

        // Adding the entity to the repository.
        _ = await _repository.AddAsync(newCustomer).ConfigureAwait(false);

        // Saving changes to the database and triggering domain events.
        var success = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (!success) return Result.Error("");

        // Returning the ID and success message.
        return Result<CustomerResponse>.Success(
            new CustomerResponse(newCustomer.Id, newCustomer.Name ?? string.Empty, newCustomer.PhoneNumber), "Successfully registered!");
    }
}
