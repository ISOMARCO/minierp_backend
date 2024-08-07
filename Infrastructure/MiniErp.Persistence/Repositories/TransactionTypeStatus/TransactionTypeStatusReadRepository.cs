using MiniErp.Application.Repositories.TransactionTypeStatus;
using MiniErp.Domain.Entities;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.TransactionTypeStatus;

public class TransactionTypeStatusReadRepository(MiniErpDbContext context) : ReadRepository<TransactionTypeStatuses>(context), ITransactionTypeStatusReadRepository
{
    
}