using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Features.CQRS.Results.TransactionTypeResults;
using MiniErp.Application.Repositories.TransactionType;

namespace MiniErp.Application.Features.CQRS.Handlers.TransactionTypesHandlers;

public class GetTransactionTypeQueryHandler(
    ITransactionTypeReadRepository readRepository
    )
{
    public async Task<List<GetTransactionTypeQueryResult>> Handle(int page, int size)
    {
        var transactionTypes = readRepository.GetAll(false).Skip(page * size).Take(size);
        return await transactionTypes.Select(transactionType => new GetTransactionTypeQueryResult
        {
            Id = transactionType.Id,
            Name = transactionType.Name,
            IsPositive = transactionType.IsPositive,
            SourceParameter = transactionType.SourceParameter,
            DestinationParameter = transactionType.DestinationParameter,
            InUse = transactionType.InUse,
            IsActive = transactionType.IsActive,
            SourceToDestinationStatus = transactionType.SourceToDestinationStatus,
            DestinationToSourceStatus = transactionType.DestinationToSourceStatus,
            Parameters = transactionType.Parameters
        }).ToListAsync();
    }
}