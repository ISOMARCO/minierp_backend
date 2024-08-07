using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Features.CQRS.Results.TransactionTypeStatusResults;
using MiniErp.Application.Repositories.TransactionTypeStatus;

namespace MiniErp.Application.Features.CQRS.Handlers.TransactionTypeStatusHandlers;

public class GetTransactionTypeStatusQueryHandler( 
        ITransactionTypeStatusReadRepository readRepository
    )
{
    public async Task<List<GetTransactionTypeStatusQueryResult>> Handle(int page, int size)
    {
        var statuses = readRepository.GetAll(false).Skip(page * size).Take(size);
        return await statuses.Select(status => new GetTransactionTypeStatusQueryResult
        {
            Id = status.Id,
            Name = status.Name,
            IsActive = status.IsActive,
            InUse = status.InUse,
            Note = status.Note
        }).ToListAsync();
    }
}