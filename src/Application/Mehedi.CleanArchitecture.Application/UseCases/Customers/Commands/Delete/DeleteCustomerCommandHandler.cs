using MediatR;
using Mehedi.Application.SharedKernel.Responses;
using Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;
using Mehedi.Core.SharedKernel;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Delete;

public class DeleteCustomerCommandHandler(ICustomerCommandRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCustomerCommand, Result>
{
    private readonly ICustomerCommandRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        _ = await _repository.DeleteByIdAsync(request.Id).ConfigureAwait(false);

        // Saving changes to the database and triggering domain events.
        var success = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (!success) return Result.Error("Error deleting customer!");

        return Result.Success();
    }
}
