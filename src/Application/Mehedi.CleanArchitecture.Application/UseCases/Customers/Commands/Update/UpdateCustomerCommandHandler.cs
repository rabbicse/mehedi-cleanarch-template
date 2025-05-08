using MediatR;
using Mehedi.Application.SharedKernel.Responses;
using Mehedi.CleanArchitecture.Application.UseCases.Customers.DTOs;
using Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;
using Mehedi.Core.SharedKernel;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Update;

public class UpdateCustomerCommandHandler(ICustomerCommandRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCustomerCommand, Result<CustomerResponse>>
{
    private readonly ICustomerCommandRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Result<CustomerResponse>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var existingCustomer = await _repository.GetByIdAsync(request.Id).ConfigureAwait(false);
        if (existingCustomer == null)
        {
            return Result.NotFound();
        }

        existingCustomer.SetName(request.Name);
        existingCustomer.SetPhoneNumber(request.Phone);

        _ = await _repository.UpdateAsync(existingCustomer).ConfigureAwait(false);

        var success = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (!success) return Result.Error("Error create customer!");

        // Returning the ID and success message.
        return Result<CustomerResponse>.Success(
            new CustomerResponse(existingCustomer.Id, existingCustomer.Name ?? string.Empty, existingCustomer.PhoneNumber), "Successfully updated!");
    }
}
