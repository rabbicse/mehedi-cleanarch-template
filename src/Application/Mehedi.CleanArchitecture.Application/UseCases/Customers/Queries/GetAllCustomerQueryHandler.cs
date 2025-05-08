// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MediatR;
using Mehedi.Application.SharedKernel.Responses;
using Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate;
using Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;

#if UseCaching
using Mehedi.Application.SharedKernel.Services;
#endif

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Queries;

public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, Result<IEnumerable<CustomerQueryModel>>>
{
#if UseCaching
    private const string CacheKey = nameof(GetAllCustomerQuery);
    private readonly ICacheService _cacheService;
#endif
    private readonly ICustomerQueryRepository _readOnlyRepository;

#if UseCaching
    public GetAllCustomerQueryHandler(ICustomerQueryRepository repository, ICacheService cacheService)
    {
        _readOnlyRepository = repository;
        _cacheService = cacheService;
    }
#else
    public GetAllCustomerQueryHandler(ICustomerQueryRepository repository)
    {
        _readOnlyRepository = repository;
    }
#endif

    public async Task<Result<IEnumerable<CustomerQueryModel>>> Handle(
        GetAllCustomerQuery request,
        CancellationToken cancellationToken)
    {
#if UseCaching
        var customers = await _cacheService.GetOrCreateAsync(CacheKey, async () =>
        {
            var (_, items) = await _readOnlyRepository.GetAllCollectionAsync().ConfigureAwait(false);
            return items;
        });
#else
        var (_, customers) = await _readOnlyRepository.GetAllCollectionAsync().ConfigureAwait(false);
#endif
        return Result<IEnumerable<CustomerQueryModel>>.Success(customers);
    }
}

